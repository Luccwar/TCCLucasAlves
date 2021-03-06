﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D hitInfo) {
        
            Debug.Log(hitInfo.name);
        if (!hitInfo.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }

    }
}
