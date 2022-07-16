using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TurnSystem : MonoBehaviour
{
    public ShipController ship;
    public Queue<Instruction> Instructions;
    public Parameter[] parameters;

    public float InstructionDelay = 1.0f;

    private void Start()
    {
        Instructions = new Queue<Instruction>();
    }

    private void FixedUpdate()
    {
        ProcessInstructions();
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

    void ProcessInstructions()
    {
        if(Instructions.Count < 1)
        {
            return;
        }

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
