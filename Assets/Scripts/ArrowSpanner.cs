using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowSpanner : MonoBehaviour
{
    public ArrowScript arrowPrefab;
    public float arrowspeed;
    private float time = 0;
    public float arrowDelay;

    public bool fromLeft = false;
    public bool fromRight = false;
    public bool shoot;

    private Vector2 dir2;


    // Start is called before the first frame update
    void Start()
    {
        dir2 = new Vector2(arrowspeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot == true)
        {
            if(time < Time.time)
            {
                ArrowScript arrow = Instantiate(arrowPrefab, transform.position,transform.rotation) as ArrowScript;
                arrow.dir = dir2;
                if (fromLeft == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0,0,180);
                }
                
                /*if (fromTop == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0,90,0);
                }*/
                else
                {
                    arrow.transform.rotation = Quaternion.Euler(0,0,0);
                }
                if (fromRight == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0,-50,180);
                }
                time=Time.time + arrowDelay;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //shoot =true;
                SceneManager.LoadScene("SampleScene");
            }
            
        
        }
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("scene2"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //shoot =true;
                SceneManager.LoadScene("scene2");
            }
            
        
        }
       
    }

   
}
