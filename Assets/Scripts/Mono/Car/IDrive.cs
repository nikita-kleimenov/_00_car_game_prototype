using UnityEngine;


public interface IDrive
{
    public float Turn { get; set; }
    public float Acceleration { get; set; }
    public float Brake { get; set; }

    public bool EngineTurned { get; set; }

    public Vector3 Velocity { get; }
    public Transform Center { get; }
}