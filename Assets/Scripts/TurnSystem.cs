using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TurnSystem : MonoBehaviour
{
    public static TurnSystem instance;
    public AudioSource source;
    private void Awake()
    {
        instance = this;
    }

    public ShipController ship;
    public Queue<Instruction> Instructions;
    public Parameter[] parameters;
    public float InstructionDelay = 1.0f;
    public Button launchButton;
    //Used to track timer
    public TimerManager timertext;


    private void Start()
    {
        if(!ship)
        {
            ship = FindObjectOfType<ShipController>();
        }
        if (!timertext)
        {
            timertext = FindObjectOfType<TimerManager>();
        }
        Instructions = new Queue<Instruction>();
        TurnActive = true;
    }

    private void FixedUpdate()
    {
        ProcessInstructions();
    }

    public void Randomize()
    {
        foreach(var param in parameters)
        {
            param.RandomizeSpeed();
        }
    }

    public void AddInstructions()
    {
        for(int i = 0; i < parameters.Length; i++)
        {
            var param = parameters[i];
            var direction = Vector2.up.Rotate(param.Angle);
            var instruction = new Instruction(ship, InstructionDelay, param.Speed * ship.baseSpeed, direction);
            Instructions.Enqueue(instruction);
        }
    }

    bool turnBegin;
    public bool TurnActive
    {
        get
        {
            return turnBegin;
        }
        private set
        {
            if(value != turnBegin)
            {
                if(value)
                {
                    OnTurnBegin();
                }
                else
                {
                    OnTurnEnd();
                }
            }

            turnBegin = value;
        }
    }


    void OnTurnBegin()
    {
        // Pauses timer
        if (timertext != null)
            timertext.SetCounting(false);

        //Debug.Log("Turn Begin!");
        launchButton.interactable = true;
        Randomize();
    }

    void OnTurnEnd()
    {
        // Unpauses timer
        if(timertext != null)
        timertext.SetCounting(true);


        source.PlayOneShot(source.clip);


        launchButton.interactable = false;
        //Debug.Log("Turn End!");
    }

    void ProcessInstructions()
    {
        if(Instructions.Count < 1)
        {
            

            TurnActive = true;
            ship.rigidBody.simulated = false;
            return;
        }

        TurnActive = false;

        ship.rigidBody.simulated = true;
        var instruction = Instructions.Peek();
        if(instruction.TimeLeft > 0)
        {

            instruction.Process();
            instruction.TimeLeft -= Time.deltaTime;
        }
        else
        {
            Instructions.Dequeue();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
