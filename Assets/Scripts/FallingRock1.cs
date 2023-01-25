using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class FallingRock1 : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
        {
            if(col.gameObject.name.Equals("Luffy"))
            {
                rb.isKinematic= false;
                //SceneManager.LoadScene("SampleScene");
            }
        }
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("scene2"))
        {
            if(col.gameObject.name.Equals("Luffy"))
            {
                rb.isKinematic= false;
                //SceneManager.LoadScene("SampleScene");
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Equals("Luffy"))
        {
            Debug.Log("Falling");
        }
    }
}
