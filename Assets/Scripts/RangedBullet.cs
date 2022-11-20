using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBullet : MonoBehaviour
{
    private int maxRange;
    private Vector2 parent;
    private Rigidbody2D rigidBody;

    // Update is called once per frame

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(this.transform.position, parent) > maxRange)
        {
            Destroy(gameObject);
        }
    }

    public void SetRangeParams(int range, Vector2 parentPos)
    {
        transform.position = parentPos;
        maxRange = range;
        parent = parentPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}