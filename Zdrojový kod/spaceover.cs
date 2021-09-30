using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceover : MonoBehaviour
{

    Plane playerScript;
    GameObject Player;
    GameObject Player2;
    plane2 player2Script;
    planeHP2 player2HP;
    planeHP playerHP;

    public GameObject menu;
    public GameObject Audio;
    public GameObject Help;
    public GameObject Play;
    bool Aktivni;

    void Start()
    {
        Aktivni = false;
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<Plane>();
        Player2 = GameObject.Find("Player2");
        player2Script = Player2.GetComponent<plane2>();
        player2HP = Player2.GetComponent<planeHP2>();
        playerHP = Player.GetComponent<planeHP>();
    }

    int aktualni;
    int aktualni2;
    public Text body;
    public Text body2;



    public Text win1;
    public Text win2;

    public Text Round1;
    public Text Round2;
    public Text Round3;
    public Text Round4;
    public Text Round5;
    int pocet = 1;

    public float count = 3;
    float freez = 2.5f;

    // Update is called once per frame
    void Update()
    {
        Rounds();
        if (win1.enabled == true)
        {
            count -= Time.deltaTime;

        }
        if (win2.enabled == true)
        {
            count -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            /*if(!menu.activeSelf)
             {
                 menu.SetActive(true);
             }
            if (menu.activeSelf)
             {
                 menu.SetActive(false);
             }
            */
            Aktivni = !Aktivni;
            menu.SetActive(Aktivni);
            Audio.SetActive(false);
            Help.SetActive(false);
            Play.SetActive(false);


        }
    }


    void Rounds()
    {
        Debug.Log(pocet);

        if (Round1.enabled == true)
        {
            freez -= Time.deltaTime;
            playerHP.health.value = 100;
            player2HP.health.value = 100;
            player2Script.currenthp = 100;
            playerScript.currenthp = 100;
        }
        if (Round2.enabled == true)
        {
            freez -= Time.deltaTime;
            playerHP.health.value = 100;
            player2HP.health.value = 100;
            player2Script.currenthp = 100;
            playerScript.currenthp = 100;
        }
        if (Round3.enabled == true)
        {
            freez -= Time.deltaTime;
            playerHP.health.value = 100;
            player2HP.health.value = 100;
            player2Script.currenthp = 100;
            playerScript.currenthp = 100;
        }
        if (Round4.enabled == true)
        {
            freez -= Time.deltaTime;
            playerHP.health.value = 100;
            player2HP.health.value = 100;
            player2Script.currenthp = 100;
            playerScript.currenthp = 100;
        }
        if (Round5.enabled == true)
        {
            freez -= Time.deltaTime;
            playerHP.health.value = 100;
            player2HP.health.value = 100;
            player2Script.currenthp = 100;
            playerScript.currenthp = 100;
        }
        if (freez < 0)
        {
            Round1.enabled = false;
            Round2.enabled = false;
            Round3.enabled = false;
            Round4.enabled = false;
            Round5.enabled = false;

        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Player")
        {

            

            aktualni2++;

            body2.text = aktualni2.ToString();
            if (aktualni2 == 3)
            {
                win2.enabled = true;
            }

        }

        if (col.gameObject.name == "Player2")
        {
            

            aktualni++;

            body.text = aktualni.ToString();
            if (aktualni == 3)
            {
                win1.enabled = true;

            }

        }

        if (col.gameObject.tag == "Player")
        {
            Player2.transform.position = new Vector3(536.6f, 105.8f, 0);
            Player.transform.position = new Vector3(234.9f, 100.4f, 0);


            pocet += 1;
            freez = 2.5f;
            if (pocet == 1)
            {
                Round1.enabled = true;
            }
            if (pocet == 2)
            {
                Round2.enabled = true;
            }
            if (pocet == 3)
            {
                Round3.enabled = true;
            }
            if (pocet == 4)
            {
                Round4.enabled = true;
            }
            if (pocet == 5)
            {
                Round5.enabled = true;
            }




        }

    }
}
