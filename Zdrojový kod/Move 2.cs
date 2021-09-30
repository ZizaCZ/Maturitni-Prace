using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_2 : MonoBehaviour 
{



    public Transform WeaponSlot;
    public Transform Gun;
    public Transform Player;
    public Transform Hand;

    Rigidbody2D m_rigidbody2;
    Animator m_Animator2;
    Transform m_tran2;

    private float h = 0;
    private float v = 0;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public LayerMask groundLayer;
    public float MoveSpeed = 40f;
    public float JumpForce = 20f;

    public SpriteRenderer[] m_SpriteGroup;

    public bool Once_Attack = false;
    public bool B_Attack;
    public bool B_FacingRight;

    // Use this for initialization
    void Start()
    {
        m_rigidbody2 = this.GetComponent<Rigidbody2D>();
        m_Animator2 = this.transform.GetComponent<Animator>();
        m_tran2 = this.transform;
        m_SpriteGroup = this.transform.Find("Player").GetComponentsInChildren<SpriteRenderer>(true);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);

        spriteOrder_Controller();


        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Once_Attack = false;
            Debug.Log("Lclick");
            m_Animator2.SetTrigger("Attack");

            m_rigidbody2.velocity = new Vector3(0, 0, 0);


        }

        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Once_Attack = false;
            Debug.Log("Rclick");
            m_Animator2.SetTrigger("Attack2");

            m_rigidbody2.velocity = new Vector3(0, 0, 0);



        }


        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {

            Debug.Log("1");
            m_Animator2.Play("Hit");




        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("2");
            m_Animator2.Play("Die");


        }




        Move_Fuc();


        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");



        m_Animator2.SetFloat("MoveSpeed", Mathf.Abs(h) + Mathf.Abs(v));


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
            m_rigidbody2.AddForce(Vector2.left * MoveSpeed);
            if (B_FacingRight)
            {
                Filp();
            }


        }
        else if (Input.GetKey(KeyCode.D))
        {
            //  Debug.Log("RightArrow");
            m_rigidbody2.AddForce(Vector2.right * MoveSpeed);
            if (!B_FacingRight)
            {
                Filp();
            }
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            // Debug.Log("UpArrow");
            m_rigidbody2.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log("DownArrow");
            m_rigidbody2.AddForce(Vector2.down * MoveSpeed);


        }




    }


    // character Filp 


    void Filp()
    {
        B_FacingRight = !B_FacingRight;
        if (B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if (!B_FacingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
