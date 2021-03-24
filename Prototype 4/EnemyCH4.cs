using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCH4 : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
