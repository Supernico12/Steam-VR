﻿


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//

public class EnemyMovement : MonoBehaviour
{



    Animator anim;

    public Transform player;
    GameObject enemy;
    [SerializeField]
    int range;
    int distance;
    public float speed;
    public NavMeshAgent agent;
    public Transform destination;
    public bool canMove = true;
    CharacterStats playerStats;
    [SerializeField] float damage = 4;



    // Use this for initialization
    void Start()
    {

        Debug.Log(player);
        player = PlayerManager.instance.playertransform;

        agent = GetComponent<NavMeshAgent>();
        playerStats = player.GetComponent<CharacterStats>();
        player = dointDestroy.playerInstance.GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {

        if (Vector3.Distance(transform.position, player.position) < range)
        {
            if (canMove)
            {
                destination = player;
                agent.SetDestination(destination.position);
            }
            if (Vector3.Distance(transform.position, player.position) < 4f)
            {
                //playerStats.TakeDamage(Time.deltaTime * damage);
            }
        }

        }
    }


    public void Suicide()
    {
        GetComponent<EnemyDamage>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}

