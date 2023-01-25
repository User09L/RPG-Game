using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Movement: MonoBehaviour
{
     public Animator animator;
     public SpriteRenderer sprite;
     public float moveSpeed = 1.0f;
     protected bool idle=true, walking=false, jumping = false, punching=false, kicking=false;
     public Rigidbody2D rb;
     public GameObject go;
     public Text text1,text2;
     public bool isJumping;
     public  float x;
     

     

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
       
        Walking();
        Idle();
        Jumping();
        //Boundary();

        var input = Input.inputString;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) 
        {
            idle = false;
            walking = true;
            jumping = false;
            punching = false;
            kicking = false;
     
           animator.SetBool ("Idle", idle);
           animator.SetBool ("Walking", walking);
           animator.SetBool ("Jumping", jumping);
           animator.SetBool ("Punching", punching);
           animator.SetBool ("Kicking", kicking);

            if(input.Equals("d"))
            {
                sprite.flipX = false;
            }
            else if (input.Equals("a"))
            {
               sprite.flipX = true;
            }
         }

         else if(Input.GetKey(KeyCode.Space))
          {
             jumping = true;
             idle = false;
             walking = false;
             punching = false;
             kicking = false;
             animator.SetBool ("Idle", idle);
             animator.SetBool ("Jumping", jumping);
             animator.SetBool ("Walking", walking);
             animator.SetBool ("Punching", punching);
             animator.SetBool ("Kicking", kicking);
            
         }
         else if(Input.GetKey(KeyCode.J))
         {
             jumping = false;
             idle = false;
             walking = false;
             punching = true;
             kicking = false;
             animator.SetBool ("Idle", idle);
             animator.SetBool ("Jumping", jumping);
             animator.SetBool ("Walking", walking);
             animator.SetBool ("Punching", punching);
             animator.SetBool ("Kicking", kicking);
         }
         else if(Input.GetKey(KeyCode.K))
         {
             jumping = false;
             idle = false;
             walking = false;
             punching = false;
             kicking = true;
             animator.SetBool ("Idle", idle);
             animator.SetBool ("Jumping", jumping);
             animator.SetBool ("Walking", walking);
             animator.SetBool ("Punching", punching);
             animator.SetBool ("Kicking", kicking);
         }


       
        else
         {
           idle = true;
           walking = false;
           jumping = false;
           punching = false;
           kicking = false;
           animator.SetBool ("Idle", idle);
           animator.SetBool ("Walking", walking);
           animator.SetBool ("Jumping", jumping);
           animator.SetBool ("Punching", punching);
           animator.SetBool ("Kicking", kicking);
         }
      
       //if(go.transform.position.y < -6){    //this code loads again the scene if y position of luffy is >-4
             //SceneManager.LoadScene("SampleScene");

       
  
    }



    public void Init()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        go= GameObject.FindWithTag("Player");
        rb = go.GetComponent<Rigidbody2D>();
        rb.freezeRotation=true;
        //text1 = GameObject.FindWithTag("mytxt").GetComponent<Text>();
        //text2 = GameObject.FindWithTag("mytxt2").GetComponent<Text>();
       

    }
    


    void Walking()
    {
        if (walking)
        {
            go.transform.Translate(Vector2.right* Input.GetAxis("Horizontal") * moveSpeed* Time.deltaTime);

           //go.GetComponent<Rigidbody2D>().velocity=new Vector2(go.GetComponent<Rigidbody2D>().velocity.x,2);
        }
    }

   void Idle()
    {
        if(idle)
        {
        
        }

    }

    void Jumping()
     {
        if(jumping && !isJumping)
        {
            SoundManagerScript.PlaySound("jumpsound");
            float jumpVelocity = 6.5f;
            rb.velocity = Vector2.up* jumpVelocity;
            //rb.velocity = new Vector2(rb.velocity.x,2);
            isJumping = true;

        }
        
     }

    void Boundary()
    {
        //x = go.transform.position.x;
        if(go.transform.position.x <-8)
        {
            //Vector3 temp = new Vector3(5f,0,0);
           go.transform.position = new Vector3(go.transform.position.x + 0.2f, go.transform.position.y, go.transform.position.z); 
        }
        if(go.transform.position.x >31)
        {
            //Vector3 temp = new Vector3(5f,0,0);
            go.transform.position = new Vector3(go.transform.position.x - 0.2f, go.transform.position.y, go.transform.position.z);
        }
    }
        
       
            
        void OnCollisionEnter2D (Collision2D col)
        {
            if(col.transform.tag == "Arrow")
            {
                Destroy(col.gameObject);
            }
            if (col.gameObject.CompareTag("Ground")){
                isJumping = false;
            }

            
            if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
            {
                if (col.gameObject.CompareTag("Arrow"))
                {
                    SoundManagerScript.PlaySound("arrowhit");
                    SceneManager.LoadScene("SampleScene");
                }
                if (col.gameObject.CompareTag("Next"))
                {
                    SceneManager.LoadScene("scene2");
                }
                if (col.gameObject.CompareTag("FRock"))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
            if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("scene2"))
            {
                if (col.gameObject.CompareTag("Arrow"))
                {
                    SoundManagerScript.PlaySound("arrowhit");
                    SceneManager.LoadScene("scene2");
                }
                if (col.gameObject.CompareTag("Next"))
                {
                    SceneManager.LoadScene("End Scene");
                }
                if (col.gameObject.CompareTag("FRock"))
                {
                    SceneManager.LoadScene("scene2");
                }
            }
            

            
        }
}


