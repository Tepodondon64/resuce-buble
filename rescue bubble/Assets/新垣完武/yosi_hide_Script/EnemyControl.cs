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
    private float searchTime = 0;
    public float ENEMY_MOVE_SPEED = 0.05f;
    private Animator animator;

    EnemyStatus enemystatus;

    private EnemyControl EM ;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //追跡したいオブジェクトの名前を入れる
        player = GameObject.Find("Player");
        enemystatus = GetComponent<EnemyStatus>();
        EM = GetComponent<EnemyControl>();
    }

    void Update()
    {
        playerPos = this.player.transform.position;
        playerPos.y = this.transform.position.y;
        this.transform.LookAt(playerPos);
        //this.transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, ENEMY_MOVE_SPEED);

        if(enemystatus.enemy_hp <= 0)
        {
            EM.enabled = false;
            this.tag = "Untagged";
        }

        animator.SetTrigger("Idou");
    }
}

