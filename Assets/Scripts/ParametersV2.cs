using TMPro;

public class ParametersV2 : Parameter
{
    public KnobController knob;
    public DiceRollValue SpeedInput;

    public override float Angle
    {
        get
        {
            return knob.Value * 360.0f;
        }

        set
        {
            knob.Value = value;
        }
    }


    public override float Speed
    {
        get
        {
            float defaultSpeed = 0.0f;

            float.TryParse(SpeedInput.text.text, out defaultSpeed);

            return defaultSpeed;
        }

        set
        {
            speed = value;

            SpeedInput.text.text = speed.ToString();
        }
    }
}

