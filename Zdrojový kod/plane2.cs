using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plane2 : MonoBehaviour
{
    public int PlayerHP = 100;
    public float currenthp = 100;

    public float PlayerX;
    public float PlayerY;
    public float PlayerZ;

    public Transform Player;
    public float MoveSpeed = 5f;

    public GameObject Ammo;
    public Transform firepoint;

    public bool B_FacingRight;

    public Rigidbody2D m_rigidbody2;

    public bool B_FacingUp;

    public bool Freeze = false;

    void Start()
    {
        m_rigidbody2 = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject Zone = GameObject.Find("Zone");
        spaceover zoneScript = Zone.GetComponent<spaceover>();

        PlayerX = Player.position.x;
        PlayerY = Player.position.y;
        PlayerZ = Player.position.z;


        if (zoneScript.Round1.enabled == true)
        {
            Freeze = true;
        }
        if (zoneScript.Round2.enabled == true)
        {
            Freeze = true;
        }
        if (zoneScript.Round3.enabled == true)
        {
            Freeze = true;
        }
        if (zoneScript.Round4.enabled == true)
        {
            Freeze = true;
        }
        if (zoneScript.Round5.enabled == true)
        {
            Freeze = true;
        }
        else
        {
            Freeze = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Ammo, firepoint.position, firepoint.rotation);

        }

        if (zoneScript.count < 0)
        {

            SceneManager.LoadScene(0);

        }

        Move_Fuc();
    }
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A) && Freeze == false)
        {
            //  Debug.Log("LeftArrow");
            m_rigidbody2.velocity = new Vector2(-1 * MoveSpeed, m_rigidbody2.velocity.y);

            if (B_FacingRight)
            {
                Flip();

            }


        }



        else if (Input.GetKey(KeyCode.D) && Freeze == false)
        {
            //  Debug.Log("RightArrow");
            m_rigidbody2.velocity = new Vector2(1 * MoveSpeed, m_rigidbody2.velocity.y);
            if (!B_FacingRight)
            {
                Flip();

            }

        }



        else if (Input.GetKey(KeyCode.W) && Freeze == false)
        {
            // Debug.Log("UpArrow");
            m_rigidbody2.velocity = new Vector2(m_rigidbody2.velocity.x, 1 * MoveSpeed);
            if (!B_FacingUp)
            {
                Flip2();
            }

        }

        if (Input.GetKey(KeyCode.S) && Freeze == false)
        {
            // Debug.Log("DownArrow");
            m_rigidbody2.velocity = new Vector2(m_rigidbody2.velocity.x, -1 * MoveSpeed);

            if (B_FacingUp)
            {
                Flip2();
            }
        }




    }

    void Flip2()
    {
        B_FacingUp = !B_FacingUp;
        if (B_FacingUp)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (!B_FacingUp)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
    }

    void Flip()
    {
        B_FacingRight = !B_FacingRight;
        if (B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);

        }
        if (!B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);

        }
    }
}
