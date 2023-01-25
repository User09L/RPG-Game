using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class Movement_SQLite: MonoBehaviour
{

     public Animator animator;
     public SpriteRenderer sprite;
     public float moveSpeed = 1.0f;
     protected bool idle=true, walking=false, jumping = false, punching=false, kicking=false;
     public Rigidbody2D rb;
     public GameObject go, go2,go3;
     public Text text2;
     public IDbConnection dbcon;
     public IDbCommand dbcmd;


     

    // Start is called before the first frame update
    void Start()
    {
        Init();
        SqliteSetup();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Walking();
        Idle();
        Jumping();

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
      
       if(go.transform.position.y < -4){    //this code loads again the scene if y position of luffy is >-4
             SceneManager.LoadScene("SampleScene");

       }
  
    }


    public void Init()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        go= GameObject.FindWithTag("Player");
        go2= GameObject.FindWithTag("pts");
        go3= GameObject.FindWithTag("pts2");
        rb = go.GetComponent<Rigidbody2D>();
        rb.freezeRotation=true;
        text2 = GameObject.FindWithTag("mytxt2").GetComponent<Text>();

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
        if(jumping)
        {
           rb.velocity = new Vector2(rb.velocity.x,2);
        }

     }

    void OnCollisionEnter2D (Collision2D col)
      {
        if(col.gameObject.tag=="pts"){    //an object in the game has been tagged
                   go2.GetComponent<SpriteRenderer>().enabled=false;               
                   go2.SetActive(false);     
                  
                   // Insert values in table
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = "INSERT INTO tbl (object, power) VALUES ('Object1', 10)";
		cmnd.ExecuteNonQuery();
        
		  
         }

	if(col.gameObject.tag=="pts2"){    //an object in the game has been tagged
                   go3.GetComponent<SpriteRenderer>().enabled=false;               
                   go3.SetActive(false);  
                 
                  // Insert values in table   
                 IDbCommand cmnd = dbcon.CreateCommand();
		 cmnd.CommandText = "INSERT INTO tbl (object, power) VALUES ('Object1', 25)";
		 cmnd.ExecuteNonQuery();
           
         }
          
         // Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query ="SELECT sum(power) FROM tbl";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
			Debug.Log("sum of power: " + reader[0].ToString());
                        text2.text = reader[0].ToString() ;
                       
		}
               
      
      }

    void SqliteSetup()
    {

                // Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "My_DB";
		
		// Open connection
		dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Create table
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS tbl (object VARCHAR, power INTEGER )";
		
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();
    }


}
