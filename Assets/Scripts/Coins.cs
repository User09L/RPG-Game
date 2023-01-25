using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;  

public class Coins : MonoBehaviour
{
    private float coin = 0;

    //public TextMeshProUGUI textCoins;  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("SampleScene"))
        {
            if(col.transform.tag == "coins")
            {
                SoundManagerScript.PlaySound("coins");
                StartCoroutine(storeCollectedItem("http://localhost/unity/fexer/collectData.php","coin1","10")); 
                //coin++;
                //textCoins.text = coin.ToString();
                Destroy(col.gameObject);
            }
        }
        if (SceneManager. GetActiveScene () == SceneManager.GetSceneByName ("scene2"))
        {
            if(col.transform.tag == "coins")
            {
                SoundManagerScript.PlaySound("coins");
                StartCoroutine(storeCollectedItem("http://localhost/unity/fexer/collectData.php","coin2","10")); 
                //coin++;
                //textCoins.text = coin.ToString();
                Destroy(col.gameObject);
            }
        }

        
       

    }

    IEnumerator storeCollectedItem(string url, string Object, string coins)
    {
        WWWForm form = new WWWForm();
        form.AddField("Object", Object);
        form.AddField("coins", coins);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        // text1.text=uwr.downloadHandler.text;
        }
    }
    
}
