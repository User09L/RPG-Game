using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      

public class ArrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject go,go6;
    public Animator animator;
    public SpriteRenderer sprite;
    public Vector2 dir= new Vector2(2,2);
    
    
    // Start is called before the first frame update
    void Start()
    {
        go6=GameObject.FindWithTag("Arrow");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dir;

        if(gameObject.name == "Arrow(Clone)")
        {
         Destroy(gameObject, 2);
        }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        /*
        if(col.transform.tag == "Wall")
        {
            Destroy(go6,arrowLife);
        }
        if(col.transform.tag == "Spikes")
        {
            Destroy(go6,arrowLife);
        }
        */
        
        /*
        if (col.gameObject.CompareTag("Wall"))
        {
            go6.SetActive(false);
        }
         if (col.gameObject.CompareTag("Spikes"))
        {
            go6.SetActive(false);
        }
        */
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
        {
                if (col.gameObject.CompareTag("Arrow"))
                {
                    SoundManagerScript.PlaySound("arrowhit");
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
        }
        
    }
    
    

}
