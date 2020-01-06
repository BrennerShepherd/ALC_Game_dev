﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12; private float maxSpeed = 16;
    private float maxTorque = 10; private float xRange = 4;
    private float ySpawnPos = -6;
    private Gamemanager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),
        RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        if (gameManager != null)
        {
            gameManager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
        }
     
    }

    Vector3 RandomForce() { return Vector3.up * Random.Range(minSpeed, maxSpeed); }
    float RandomTorque() {  return Random.Range(-maxTorque, maxTorque); }
    Vector3 RandomSpawnPos() { return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (gameManager != null)
            {
                gameManager.UpdateScore(pointValue);
            }
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
