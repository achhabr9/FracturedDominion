using UnityEngine;

public class EnemyReputationAI : MonoBehaviour
{
    public float detectionRange = 5f;
    public int hostilityThreshold = -10; // attack if rep is below this
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange && FactionReputation.Instance.GetReputation("Syndicate") < hostilityThreshold)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * 4f * Time.deltaTime;
    }
}
