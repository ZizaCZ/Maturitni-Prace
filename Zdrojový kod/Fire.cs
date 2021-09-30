using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject pisbullet;
    public float dmg = 20f;
    public Rigidbody2D bullet;
    public float speed = 5f;
    void Update()
    {
        bullet.AddForce(transform.right * speed);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(pisbullet);
        }
    }

}
