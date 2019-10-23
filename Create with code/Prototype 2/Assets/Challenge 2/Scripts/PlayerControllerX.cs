using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetButton("Jump") && Time.time > nextFire)

        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(dogPrefab, transform.position, transform.rotation) as GameObject;
            //Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
