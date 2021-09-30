using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planeHP2 : MonoBehaviour
{
    public Slider health;
    GameObject Player;
    plane2 PlayerScript;
    public float push;
    public GameObject LaserBomb;
    public GameObject LaserBomb2;
    LaserBomb BombScript;
    LaserBomb BombScript2;

    void Start()
    {
        Player = GameObject.Find("Player2");
        PlayerScript = Player.GetComponent<plane2>();
        BombScript = LaserBomb.GetComponent<LaserBomb>();
        BombScript2 = LaserBomb2.GetComponent<LaserBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        health.value = PlayerScript.currenthp / 100;
        push = PlayerScript.currenthp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LBomb")
        {
            PlayerScript.currenthp -= BombScript.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
            Destroy(col.gameObject);
            PlayerScript.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }
        else if (col.gameObject.tag == "LBomb2")
        {
            PlayerScript.currenthp -= BombScript2.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
            Destroy(col.gameObject);
            PlayerScript.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }

    }
}
