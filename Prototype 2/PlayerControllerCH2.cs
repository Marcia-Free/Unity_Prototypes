﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCH2 : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Player movement left to right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }
}