using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {

    private NavMeshAgent agent;

    public GameObject target;
    Vector3 playerPos;
    GameObject player;
    float distance;
    public float trackingRange = 8f;
    public float quitRange = 5f;
    public bool pi = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);

        if(pi)
        {
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
                pi = false;

            //Playerを目標とする
            agent.destination = playerPos;
        }

        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange)
                pi = true;
        }
    }
}

