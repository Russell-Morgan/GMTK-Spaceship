using TMPro;

public class ParameterTest : Parameter
{
    public TMP_InputField AngleInput; 
    public TMP_InputField SpeedInput; 

    public override float Angle
    {
        get
        {
            float defaultAngle = 0.0f;

            float.TryParse(AngleInput.text, out defaultAngle);

            return defaultAngle;
        }

        set
        {
            angle = value;

            AngleInput.text = angle.ToString();
        }
    }


    public override float Speed
    {
        get
        {
            float defaultSpeed = 0.0f;

            float.TryParse(SpeedInput.text, out defaultSpeed);
            
            return defaultSpeed;
        }

        set
        {
            speed = value;

            SpeedInput.text = speed.ToString();
        }
    }
}

