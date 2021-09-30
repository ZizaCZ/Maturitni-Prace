using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBomb : MonoBehaviour
{
    public float dmg = 10f;
    public Rigidbody2D Bomb;
    public float speed = 20f;

    void Update()
    {
        Bomb.AddForce(transform.right * speed*100);
    }

}
