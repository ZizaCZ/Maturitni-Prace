using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawner : MonoBehaviour
{
    public Transform spawnpoint;
    void Start()
    {

    }

    void Update()
    {
        GameObject Bazooka = GameObject.Find("Bazooka");
        GameObject SMG = GameObject.Find("SMG");
        GameObject M4 = GameObject.Find("Pixel-Rifle");
        GameObject MP5 = GameObject.Find("Pixel-SMG");
        GameObject magnum = GameObject.Find("Pixel-Magnum");
        GameObject pistol = GameObject.Find("Pixel-Pistol");
        GameObject rifle = GameObject.Find("Pixel-AssaultRifle");
        pistol pisScript = pistol.GetComponent<pistol>();
        Weapon playerScript = rifle.GetComponent<Weapon>();
        magnum magScript = magnum.GetComponent<magnum>();
        MP5 smgScript = MP5.GetComponent<MP5>();
        M4 m4Script = M4.GetComponent<M4>();
        SMG SmgScript = SMG.GetComponent<SMG>();
        Bazooka bazScript = Bazooka.GetComponent<Bazooka>();



        int rnd = Random.Range(1, 400);
        Debug.Log(rnd);

        if (rnd == 1 && Bazooka.transform.parent==null)
        {
            Bazooka.transform.position = spawnpoint.transform.position;
        }
        else if (rnd == 2 && SMG.transform.parent == null)
        {
            SMG.transform.position = spawnpoint.transform.position;
        }
        else if (rnd == 3 && MP5.transform.parent == null)
        {
            MP5.transform.position = spawnpoint.transform.position;
        }
        else if (rnd == 4 && M4.transform.parent == null)
        {
            M4.transform.position = spawnpoint.transform.position;
        }
        else if (rnd == 5 && rifle.transform.parent == null)
        {
            rifle.transform.position = spawnpoint.transform.position;
        }



    }



}
