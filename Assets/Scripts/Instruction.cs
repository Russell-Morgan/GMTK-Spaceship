using UnityEngine;

[System.Serializable]
public class Instruction
{
    public float Speed;
    public float TimeLeft;
    public Vector2 direction;

    public ShipController ship;

    bool performed = false;

    public Instruction(ShipController ship, float time, float speed, Vector2 direction)
    {
        this.direction = direction;
        this.ship = ship;
        this.TimeLeft = time;
        this.Speed = speed;
    }

    public void Process()
    {
        if (TimeLeft > 0.5)
        {
            ship.rigidBody.rotation = Mathf.LerpAngle(ship.rigidBody.rotation, Vector2.SignedAngle(Vector2.up, direction), Time.fixedDeltaTime * ship.turnSpeed);
        }
        else
        {
            if (performed)
            {
                return;
            }

            performed = true;

            ship.rigidBody.AddForce(direction.normalized * Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            DebugPlus.DrawRay(ship.transform.position, direction).duration = 2.0f;
        }
    }
}
