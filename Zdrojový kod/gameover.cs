using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameover : MonoBehaviour
{
  public  float PlayerXX;
  public  float PlayerYY;
  public  float PlayerZZ;


    Move playerScript;
    GameObject Player;
    GameObject Player2;
    Move3 player2Script;
    HP player2HP;
    Health playerHP;

    public GameObject menu;
    public GameObject Audio;
    public GameObject Help;
    public GameObject Play;
    bool Aktivni;

   public float Player2XX;
   public float Player2YY;
   public float Player2ZZ;

    void Start()
    {
        Aktivni = false;
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<Move>();
        Player2 = GameObject.Find("Player2");
        player2Script = Player2.GetComponent<Move3>();
        player2HP = Player2.GetComponent<HP>();
        playerHP = Player.GetComponent<Health>();


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

    void Update()
    {
        PlayerZZ = playerScript.PlayerZ;
        Player2ZZ = player2Script.PlayerZ;

        Rounds();

        if (win1.enabled == true)
        {
            count -= Time.deltaTime;

        }
        if (win2.enabled == true)
        {
            count -= Time.deltaTime;
        }

        if (count < 0)
        {
            SceneManager.LoadScene(0);
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


            

            aktualni ++;

            body.text = aktualni.ToString();
            if (aktualni == 3)
            {
                win1.enabled = true;

            }

        }

        if (col.gameObject.tag == "Player")
        {

            if (player2Script.B_FacingRight)
            {
                Player2.transform.localRotation = Quaternion.Euler(0, 180, 0);
                Player2.transform.position = new Vector3(91, 4.7f, 1.902033f);
            }
            else
            {
                Player2.transform.position = new Vector3(91, 4.7f, -1.902033f);
            }



            if (playerScript.B_FacingRight)
            {
                Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
                Player.transform.position = new Vector3(7.56f, 4.57f, 1.902033f);
            }
            else
            {
                Player.transform.position = new Vector3(7.56f, 4.57f, -1.902033f);
            }


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
