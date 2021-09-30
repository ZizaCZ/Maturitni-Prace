using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public Transform Gun;

    public Transform Player;
    public Transform Player2;


    GameObject thePlayer;
    Move playerScript;
    GameObject thePlayer2;
    Move3 playerScript2;

    public bool CanPick = false;
    public bool CanPick1 = false;



    void Start()
    {

    }

    void Update()
    {


        thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<Move>();

        thePlayer2 = GameObject.Find("Player2");
        playerScript2 = thePlayer2.GetComponent<Move3>();



    }
    public void PickUp1()
    {
        if (playerScript2.WeaponSlot.childCount == 0)
        {
            Gun.transform.parent = playerScript2.WeaponSlot.transform;
            Gun.transform.position = new Vector2(playerScript2.Hand.position.x, playerScript2.Hand.position.y + 0.3f);
            Gun.transform.parent = playerScript2.WeaponSlot.transform;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 26.759f);
        }
        else if (playerScript2.WeaponSlot.childCount == 1)
        {

            if (playerScript2.B_FacingRight == false)
            {

                Gun.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            playerScript2.currentweapon.transform.SetParent(null);
            Gun.transform.parent = playerScript2.WeaponSlot.transform;
            Gun.transform.position = new Vector2(playerScript2.Hand.position.x, playerScript2.Hand.position.y + 0.3f);
            Gun.transform.parent = playerScript2.WeaponSlot.transform;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 26.759f);
        }
    }

    public void PickUP()
    {
        if (playerScript.WeaponSlot.childCount == 0)
        {
            Gun.transform.parent = playerScript.WeaponSlot.transform;
            Gun.transform.position = new Vector2(playerScript.Hand.position.x, playerScript.Hand.position.y + 0.3f);
            Gun.transform.parent = playerScript.WeaponSlot.transform;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 26.759f);
        }
        else if (playerScript.WeaponSlot.childCount == 1)
        {

            if (playerScript.B_FacingRight == false)
            {

                Gun.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            playerScript.currentweapon.transform.SetParent(null);
            Gun.transform.parent = playerScript.WeaponSlot.transform;
            Gun.transform.position = new Vector2(playerScript.Hand.position.x, playerScript.Hand.position.y + 0.3f);
            Gun.transform.parent = playerScript.WeaponSlot.transform;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 26.759f);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            CanPick = true;

        }
        if (col.gameObject.name == "Player2")
        {
            CanPick1 = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.name == "Player")
        {
            CanPick = false;
        }
        if (col.gameObject.name == "Player2")
        {
            CanPick1 = false;
        }
    }
}
