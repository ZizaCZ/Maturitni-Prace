using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move3 : MonoBehaviour {

    public int PlayerHP = 100;
    public float currenthp = 100;



    public float PlayerX;
    public float PlayerY;
    public float PlayerZ;

    public Transform WeaponSlot;
    public Transform Player;
    public Transform Hand;
    public GameObject currentweapon;
    private Transform haha;

    public Rigidbody2D m_rigidbody2;
    Animator m_Animator2;
    Transform m_tran2;

    private float h = 0;
    private float v = 0;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public LayerMask groundLayer;
    public float MoveSpeed = 600f;
    public float JumpForce = 550f;

    public SpriteRenderer[] m_SpriteGroup;

    public bool B_FacingRight;
    
    // Use this for initialization
    void Start()
    {
        m_rigidbody2 = this.GetComponent<Rigidbody2D>();
        m_Animator2 = this.transform.GetComponent<Animator>();
        m_tran2 = this.transform;

    }



    // Update is called once per frame
    void Update()
    {
        m_Animator2.SetFloat("Speed", 1);
        m_Animator2.SetFloat("Jump", -1);


        haha = WeaponSlot.GetChild(0);
        currentweapon = haha.gameObject;


        PlayerX = Player.position.x;
        PlayerY = Player.position.y;
        PlayerZ = Player.position.z;

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


        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.55f, groundLayer);

        spriteOrder_Controller();
        
        if (Input.GetKeyDown(KeyCode.G) && playerScript.CanPick1 == true && rifle.transform.parent == null)
            {
            playerScript.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && pisScript.CanPick1 == true && pistol.transform.parent == null)
        {
            pisScript.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && magScript.CanPick1 == true && magnum.transform.parent == null)
        {
            magScript.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && smgScript.CanPick1 == true && MP5.transform.parent == null)
        {
            smgScript.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && m4Script.CanPick1 == true && M4.transform.parent == null)
        {
            m4Script.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && SmgScript.CanPick1 == true && SMG.transform.parent == null)
        {
            SmgScript.PickUp1();
        }
        else if (Input.GetKeyDown(KeyCode.G) && bazScript.CanPick1 == true && Bazooka.transform.parent == null)
        {
            bazScript.PickUp1();
        }



        Move_Fuc();
  
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            //Debug.Log("y::" + this.transform.position.y);
            //  Debug.Log("sortingOrder::" + sortingOrder);
            for (int i = 0; i < m_SpriteGroup.Length; i++)
            {

                m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

            }

            Update_Tic = 0;
        }



    }

    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //  Debug.Log("LeftArrow");
            m_rigidbody2.velocity= new Vector2(-1 * MoveSpeed, m_rigidbody2.velocity.y);

            if (B_FacingRight)
            {
                Flip();
                
            }
            m_Animator2.SetFloat("Speed", 3); 
           
        }

        

        else if (Input.GetKey(KeyCode.D))
        {
            //  Debug.Log("RightArrow");
            m_rigidbody2.velocity = new Vector2(1 * MoveSpeed,m_rigidbody2.velocity.y);
            if (!B_FacingRight)
            {
                Flip();
               
            }
            m_Animator2.SetFloat("Speed", 3);
        }

        

        else if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            // Debug.Log("UpArrow");
            m_rigidbody2.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            m_Animator2.SetFloat("Jump", 1);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log("DownArrow");
            m_rigidbody2.AddForce(Vector2.down * MoveSpeed);


        }




    }


    // character Filp 


    void Flip()
    {
        B_FacingRight = !B_FacingRight;
        if (B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(PlayerX, PlayerY,PlayerZ*-1 );
        }
        if (!B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(PlayerX, PlayerY, PlayerZ*-1);
        }
    }

}
