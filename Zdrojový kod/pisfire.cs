using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisfire : MonoBehaviour
{
    public GameObject bullet;
    public float dmg = 1f;
    public Rigidbody2D pisbullet;
    public float speed = 5f;
    void Update()
    {
        pisbullet.AddForce(transform.right * speed);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(bullet);
        }
    }

}
