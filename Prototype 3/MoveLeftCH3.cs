using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCH3 : MonoBehaviour
{
    private float speed = 25;
    private float leftBound = -15;
    private PlayerControllerCH3 playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerCH3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        { 
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
