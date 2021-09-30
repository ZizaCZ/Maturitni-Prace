using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider health;
    GameObject Player;
    Move3 Player2Script;
    public GameObject Bullet;
    Fire obejctscript;
    public float push;
    public GameObject PisBullet;
    pisfire pistol;
    public GameObject Rocket;
    public GameObject SMGbullet;
    Bazookafire bazScript;
    SMGfire smgScritp;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player2");
        Player2Script = Player.GetComponent<Move3>();
        obejctscript = Bullet.GetComponent<Fire>();
        bazScript = Rocket.GetComponent<Bazookafire>();
        smgScritp = SMGbullet.GetComponent<SMGfire>();
        pistol = PisBullet.GetComponent<pisfire>();
    }

    // Update is called once per frame
    void Update()
    {
        health.value = Player2Script.currenthp / 100;
        push = Player2Script.currenthp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            Player2Script.currenthp -= obejctscript.dmg;
            col.rigidbody.velocity = new Vector2(0,0);
            Destroy(col.gameObject);
            Player2Script.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }
        else if (col.gameObject.tag == "pisbullet")
        {

            Player2Script.currenthp -= pistol.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
            Destroy(col.gameObject);
            Player2Script.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }

        else if (col.gameObject.tag == "Rocket") 
        {
            Player2Script.currenthp -= bazScript.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
            Destroy(col.gameObject);
            Player2Script.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }
        else if (col.gameObject.tag == "SMGbullet")
        {
            Player2Script.currenthp -= smgScritp.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
            Destroy(col.gameObject);
            Player2Script.m_rigidbody2.AddForce(col.relativeVelocity * (100f - push));
        }
    }
}
