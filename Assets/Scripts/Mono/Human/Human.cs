using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IDrive
{
    [Header("Settings")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float walkSpeed;

    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private List<Rigidbody> parts;
    [SerializeField] private Transform center;
    //[SerializeField] private Rigidbody rig;

    [Header("Currant Drive Values")]
    [SerializeField] private float currantSpeed;
    public float Turn
    {
        get
        {
            return turn;
        }
        set
        {
            turn = Mathf.Lerp(turn, Mathf.Clamp(value, -1f, 1f), 0.1f);
        }
    }
    [SerializeField] protected float turn;
    public float Acceleration
    {
        get
        {
            return acceleration;
        }
        set
        {
            acceleration = Mathf.Lerp(acceleration, Mathf.Clamp(value, -1f, 1f), 0.1f);
        }
    }
    [SerializeField] protected float acceleration;
    public float Brake
    {
        get
        {
            return brake;
        }
        set
        {
            brake = Mathf.Lerp(brake, Mathf.Clamp01(value), 0.1f);
        }
    }
    [SerializeField] protected float brake;

    public bool Dead => dead;
    [SerializeField] private bool dead;
    public virtual bool EngineTurned
    {
        get => engineTurned;
        set => engineTurned = value;
    }
    private bool engineTurned;
    public Vector3 Velocity
    {
        get
        {
            return transform.forward * Acceleration * walkSpeed;
            //return rig.velocity;
        }
    }
    private Vector3 prevPos;

    public Transform Center => center;

    public void Movement()
    {
        if (dead)
            return;

        transform.position += transform.forward * Acceleration * walkSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, Turn * turnSpeed * Time.fixedDeltaTime);
        //rig.velocity = transform.forward * Acceleration * walkSpeed;
        //rig.angularVelocity = Vector3.up * Turn * turnSpeed;

        animator.SetFloat("Speed", currantSpeed + 0.1f);
    }

    private void LateUpdate()
    {
        currantSpeed = Mathf.Lerp(currantSpeed, Velocity.magnitude / walkSpeed, 0.1f);
        prevPos = transform.position;
    }

    public void Die()
    {
        dead = true;

        animator.enabled = false;
        foreach(Rigidbody part in parts)
        {
            part.isKinematic = false;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
}
