using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazookafire : MonoBehaviour
{
    public GameObject Rocket;
    public float dmg = 35f;
    public Rigidbody2D rocket;
    public float speed = 5f;

    void Update()
    {
        rocket.AddForce(transform.right * speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Destroy(Rocket);
        }
    }
}
