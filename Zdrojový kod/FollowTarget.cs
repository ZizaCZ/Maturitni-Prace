using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;

    float TargetX;
    float TargetY;
    float TargetZ;


    GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player2");
        Move3 playerScript = GetComponent<Move3>();
        TargetZ = Target.position.z;
    }
    

    private void Update()
    {
        TargetX = Target.position.x;
        TargetY = Target.position.y;

        this.transform.position = new Vector3(TargetX,TargetY,TargetZ);
    }
}
