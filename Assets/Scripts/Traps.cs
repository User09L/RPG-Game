using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    public GameObject go;
    public Animator animator;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        //Init();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        go= GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
        {
            if (col.gameObject.tag=="Spikes")
            {
                SoundManagerScript.PlaySound("spike");
                SceneManager.LoadScene("SampleScene");
            }
        
        }
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("scene2"))
        {
            if (col.gameObject.tag=="Spikes")
            {
                SoundManagerScript.PlaySound("spike");
                SceneManager.LoadScene("scene2");
            }
            
           
        
        }
        

       
    }
}
