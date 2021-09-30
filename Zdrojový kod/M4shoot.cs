using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firepoint;

    GameObject thePlayer;
    Move playerScript;
    GameObject thePlayer2;
    Move3 playerScript2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thePlayer = GameObject.Find("Player");
        playerScript = thePlayer.GetComponent<Move>();

        thePlayer2 = GameObject.Find("Player2");
        playerScript2 = thePlayer2.GetComponent<Move3>();

        if (Input.GetKeyDown(KeyCode.Space) && playerScript2.WeaponSlot.transform.GetChild(0).name == "Pixel-Rifle")
        {
            Instantiate(Bullet, firepoint.position, firepoint.rotation);

        }
        if (Input.GetKeyDown(KeyCode.P) && playerScript.WeaponSlot.transform.GetChild(0).name == "Pixel-Rifle")
        {
            Instantiate(Bullet, firepoint.position, firepoint.rotation);

        }


    }
}
