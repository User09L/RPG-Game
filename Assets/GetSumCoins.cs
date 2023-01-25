using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetSumCoins : MonoBehaviour
{
    public Text text1;
    // Start is called before the first frame update
    void Start()
    {
        text1 = GameObject.FindWithTag("mytxt").GetComponent<Text>();
        StartCoroutine(retrieveCollectedItems("http://localhost/unity/fexer/FetchData.php"));
        IEnumerator retrieveCollectedItems(string url)
        {
            WWWForm form = new WWWForm();
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received sum: " + uwr.downloadHandler.text);
                text1.text="Total Coins: "+uwr.downloadHandler.text;
            }
        }
    }

    
}
