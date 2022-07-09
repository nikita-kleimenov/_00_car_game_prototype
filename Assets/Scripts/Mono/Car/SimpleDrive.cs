using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDrive))]
public class SimpleDrive : MonoBehaviour
{
    [SerializeField] private float keepDistance = 1f;
    [Range(0, 5f), SerializeField]
    private float brakeDistance = 0.5f;
    [Range(0, 5f), SerializeField]
    private float threshold = 2f;

    public Transform FollowPoint
    {
        get => followPoint;
        set => followPoint = value;
    }
    [SerializeField] private Transform followPoint;
    [SerializeField] private List<Transform> eyeForward;

    private IDrive car;

    public float Speed => car.Velocity.magnitude;
    public Vector3 Direction
    {
        get
        {
            if (!followPoint)
                return Vector3.zero;
            return (followPoint.position - car.Center.position).normalized;
        }
    }
    public float Distance
    {
        get
        {
            if (!followPoint)
                return 0;
            return (followPoint.position - transform.position).magnitude;
        }
    }
    public float ObstacleDst
    {
        get
        {
            int count = 0;
            float distance = 0;

            foreach (Transform eye in eyeForward)
            {
                RaycastHit hit;
                if (Physics.Raycast(eye.position, eye.forward, out hit, 25, 1 << 14))
                {
                    if (hit.transform == transform || hit.transform.IsChildOf(transform) || hit.transform.tag != "SimpleCar")
                        continue;
                    count++;
                    distance += hit.distance;
                }
            }

            return count == 0 ? -1 : distance / (float)count;
        }
    }


    private void Awake()
    {
        car = GetComponent<IDrive>();
    }
    private void Start()
    {
        car.EngineTurned = true;
    }
    private void FixedUpdate()
    {
        Drive();
    }

    public void Drive()
    {
        if (!followPoint)
            return;

        float frwDot = Vector3.Dot(car.Center.forward, Direction);
        float rightDot = Vector3.Dot(car.Center.right, Direction);

        float turn = rightDot;
        float brake = (threshold + Mathf.Sqrt(car.Velocity.magnitude) * brakeDistance * 0.5f - Distance) / threshold;
        float acceleration = (Distance * 1.25f - threshold) / (Distance) * Mathf.Sqrt(Mathf.Abs(frwDot));

        float forwardDst = ObstacleDst;
        if (forwardDst != -1)
        {
            acceleration = Mathf.Max(forwardDst - keepDistance * 3, 0) / forwardDst;
            brake = (keepDistance + car.Velocity.magnitude * brakeDistance - forwardDst) / keepDistance;
        }

        car.Turn = Mathf.Lerp(car.Turn, turn, 1.25f - turn);
        car.Acceleration = acceleration;
        car.Brake = brake;
    }
    public void Stop()
    {
        car.Brake = 1;
        car.Acceleration = 0;
    }

}
