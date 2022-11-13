using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;
public class KrathongList : MonoBehaviour
{
    public List<Krathong> _krathongList = new List<Krathong>();
    // Start is called before the first frame update

    void Awake()
    {
        StartCoroutine(GetKrathongList("http://103.91.190.179/test_krathong/krathong_list/"));
    }

    void Start()
    {
        // StartCoroutine(GetKrathongList("http://103.91.190.179/test_krathong/krathong_list/"));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetKrathongList(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    var jsonResponse = webRequest.downloadHandler.text;
                    var result = JsonConvert.DeserializeObject<List<Krathong>>(jsonResponse);
                    for (int i = 0; i < result.Count; i++)//loop Count data from Factory.Json
                    {
                        _krathongList.Add(new Krathong(result[i].krathong_id.ToString(), result[i].price_type.ToString(), result[i].price.ToString(), result[i].max_floating.ToString()));
                    }
                    break;
            }
        }
    }

    public Krathong FetchKrathongByID(string krathong_id)// Fetch item by ID
    {
        for (int i = 0; i < _krathongList.Count; i++)
        {
            if (_krathongList[i].krathong_id == krathong_id)
            {
                return _krathongList[i];
            }
        }
        return null;
    }
}

[System.Serializable]
public class Krathong
{
    [JsonConstructor]
    public Krathong(
        string krathong_id,
        string price_type,
        string price,
        string max_floating

    )
    {
        this.krathong_id = krathong_id;
        this.price_type = price_type;
        this.price = price;
        this.max_floating = max_floating;
        this.sprite = Resources.Load<Sprite>("Krathong/" + krathong_id);
    }

    public string krathong_id;
    public string price_type;
    public string price;
    public string max_floating;
    public Sprite sprite;

    public Krathong()
    {
        this.krathong_id = "-1";
    }
}