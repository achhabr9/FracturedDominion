using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float waitTime = 1f;
    public float waypointTolerance = 0.3f;

    private int currentIndex = 0;
    private int direction = 1;
    private float waitTimer = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentIndex];
        Vector3 directionToTarget = target.position - transform.position;

        // Reached target
        if (directionToTarget.magnitude < waypointTolerance)
        {
            waitTimer += Time.fixedDeltaTime;
            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                currentIndex += direction;

                if (currentIndex >= waypoints.Length || currentIndex < 0)
                {
                    direction *= -1;
                    currentIndex += direction;
                }
            }
            return;
        }

        Vector3 moveDir = directionToTarget.normalized;
        Vector3 newPos = transform.position + moveDir * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}

