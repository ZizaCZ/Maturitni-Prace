using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider health;
    GameObject Player;
    Move Player2Script;
    public GameObject Bullet;
    Fire obejctscript;
    public float push;
    pisfire pistol;
    public GameObject PisBullet;
    public GameObject Rocket;
    public GameObject SMGbullet;
    Bazookafire bazScript;
    SMGfire smgScritp;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Player2Script = Player.GetComponent<Move>();
        obejctscript = Bullet.GetComponent<Fire>();
        pistol = PisBullet.GetComponent<pisfire>();
        bazScript = Rocket.GetComponent<Bazookafire>();
        smgScritp = SMGbullet.GetComponent<SMGfire>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        health.value = Player2Script.currenthp / 100;
        push = Player2Script.currenthp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Player2Script.currenthp -= obejctscript.dmg;
            col.rigidbody.velocity = new Vector2(0, 0);
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
