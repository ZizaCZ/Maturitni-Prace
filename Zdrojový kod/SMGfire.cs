using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGfire : MonoBehaviour
{
    public GameObject SMGbullet;
    public float dmg = 10f;
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
            Destroy(SMGbullet);
        }
    }

}
