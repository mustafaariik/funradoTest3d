using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public TextMeshProUGUI enemyLevelText;

    public PlayerLevel playerLevel;
    [SerializeField] GameObject player;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] int enemyLevel;
    [SerializeField] FloatingText floatingText;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        floatingText.SetLevel(enemyLevel);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public int GetEnemyLevel()
    {
        return enemyLevel;
    }

}
