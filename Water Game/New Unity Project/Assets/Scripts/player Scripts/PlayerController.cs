using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance
    {
        get { return s_Instance; }
    }

    protected static PlayerController s_Instance;




    public PlayerUI wetness;

    public float moveSpeed;
    public float vMoveSpeed;
    
    public float jumpSpeed;
    public float boosterSpeed;
    private Rigidbody2D myRidigBody;
    private Animator myAnim;
   
    public Transform waterCheck;
    public float waterCheckRadius;
    public Transform groundCheck;
    public float groundCheckRadius;
    public GameObject waterBall;
    public Transform waterBallPos;
    
    
    public LayerMask whatIsGround;
    public LayerMask whatIsWater;

    int watergunPrefs;
    public bool inWater;
    public bool isGrounded;
    public bool waterGun;
    Vector2 mousePos;
    Vector2 currentPos;


    /*public bool WaterGun
    {
        get
        {
            return waterGun;
        }
        set
        {
            waterGun = value;
        }
            
    }
    */







    void Start () {
		myRidigBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        waterGun = false;
     
    }
    private void Update()
    {

       
        
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector2 currentPos = transform.position;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius , whatIsGround);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        

        Movement();

        
        if (Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.x <= .5f)
        {
            myRidigBody.AddForce(new Vector2(300,0));
            wetness.wetness -= .5f;
            WaterBalls();
           
        }else if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.x >= .5f)
        {
            myRidigBody.AddForce(new Vector2(-300, 0));
            wetness.wetness -= .5f;
            WaterBalls();
        }
        if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.y <= .5f)
        {
            myRidigBody.AddForce(new Vector2(0, 12));
            
        }else if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.y >= .5f)
        {
            myRidigBody.AddForce(new Vector2(0, -12));
        }
       



    }

    void WaterBalls()
    {
            Debug.Log("shooting");
            GameObject projectile = Instantiate(waterBall, waterBallPos.position, Quaternion.identity);
       
    }

    
    

        /*Vector2 moveDirection = myRidigBody.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle *2, Vector3.zero);
        }
        */




    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        myAnim.SetFloat("Speed", Mathf.Abs(myRidigBody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);
        myAnim.SetBool("Watered", inWater);


        if (Input.GetButtonDown("Interact"))
        {


            Debug.Log("interact pressed");
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            myRidigBody.velocity = new Vector3((moveSpeed * horizontal * Time.deltaTime), myRidigBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            //transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
        }

           else if(Input.GetAxis("Horizontal") < 0f)
           {
            myRidigBody.velocity = new Vector3(moveSpeed * horizontal * Time.deltaTime, myRidigBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //transform.localRotation = new Quaternion(0f, 0f, 0f, 1f);
           }
        else
        {
            myRidigBody.velocity = new Vector3(0f, myRidigBody.velocity.y, 0f);
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }



        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Vector2 force = new Vector2(0, 280);
            Debug.Log("jumping");
            myRidigBody.velocity = new Vector2(0, jumpSpeed);
            
        }

        

        //movement up and right

        if (Input.GetAxis("Vertical") > 0f && inWater && Input.GetAxis("Horizontal") > 0f)
        {
            myRidigBody.velocity = new Vector3(moveSpeed * horizontal * Time.deltaTime, vMoveSpeed * vertical * Time.deltaTime, 0f);
           // transform.localRotation = new Quaternion(0f, 0f, 30f, 200f);


        }

        //movement down and right
        if (Input.GetAxis("Vertical") < 0f && inWater && Input.GetAxis("Horizontal") > 0f)
        {
            myRidigBody.velocity = new Vector3((moveSpeed * horizontal * Time.deltaTime),(vMoveSpeed * vertical * Time.deltaTime), 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
           // transform.localRotation = new Quaternion(0f, 0f, .4f, -1f);
        }


        //movement up and left
        if (Input.GetAxis("Vertical") > 0f && inWater && Input.GetAxis("Horizontal") < 0f)
        {
            myRidigBody.velocity = new Vector3(moveSpeed * horizontal * Time.deltaTime, vMoveSpeed * vertical * Time.deltaTime, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
           // transform.localRotation = new Quaternion(0f, 0f, -60f, 200f);

        }

        //movement down and left
        if (Input.GetAxis("Vertical") < 0f && inWater && Input.GetAxis("Horizontal") < 0f)
        {
            myRidigBody.velocity = new Vector3(moveSpeed* horizontal* Time.deltaTime, vMoveSpeed * vertical * Time.deltaTime, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
           // transform.localRotation = new Quaternion(0f, 0f, 60f, 200f);
        }
        
        if (Input.GetAxis("Vertical") < 0f && inWater)
        {
            myRidigBody.velocity = new Vector3(myRidigBody.velocity.x, vMoveSpeed *vertical * Time.deltaTime, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0f && inWater)
        {
            
            myRidigBody.velocity = new Vector3(myRidigBody.velocity.x, (vMoveSpeed * vertical * Time.deltaTime), 0f);
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        }
    }


    //public void SetBool(string key, bool state)
    //{
    //    PlayerPrefs.SetInt(key, state ? 1 : 0);
    //}

    //public static bool GetBool(string key)
    //{
    //    int value = PlayerPrefs.GetInt(key);

    //    if (value == 1)
    //    {
    //        return true;
    //    }

    //    else
    //    {
    //        return false;
    //    }
    //}

}
