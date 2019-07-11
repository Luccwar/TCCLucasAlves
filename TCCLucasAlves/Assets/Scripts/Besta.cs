using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Besta : MonoBehaviour
{

    public Transform firePoint;
    public GameObject arrowPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")){
            Shoot();
        }
    }

    void Shoot(){
        // Shooting Logic
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
