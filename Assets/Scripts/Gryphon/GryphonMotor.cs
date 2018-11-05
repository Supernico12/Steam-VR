using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GryphonMotor : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField]
    Transform target;

    [SerializeField]
    float interactDistance = 5;

    bool isMounted;


    public void SetMounted(bool active)
    {
        isMounted = active;

    }
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (!isMounted)
        {
            SetDestination();
        }
    }


    void SetDestination()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < interactDistance)
        {
            Move();
        }
    }

    void Move()
    {
        agent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }


}
