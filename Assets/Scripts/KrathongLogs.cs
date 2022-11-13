using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class KrathongLogs : MonoBehaviour
{
    public List<KrathongLog> _krathongLog = new List<KrathongLog>();
    private string url = "http://103.91.190.179/test_krathong/krathong_logs/";
    // Start is called before the first frame update

    void Awake()
    {
        StartCoroutine(GetKrathongLogs(url));
    }

    void Start()
    {
        // StartCoroutine(GetKrathongLogs(url));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetKrathongLogs(string uri)
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
                    var result = JsonConvert.DeserializeObject<List<KrathongLog>>(jsonResponse);
                    for (int i = 0; i < result.Count; i++)//loop Count data from Factory.Json
                    {
                        _krathongLog.Add(new KrathongLog(result[i].userid.ToString(), result[i].fbname.ToString(), result[i].wish.ToString(), result[i].krathong_id.ToString()));
                    }
                    break;
            }
        }
    }

    public KrathongLog FetchKrathongByID(string krathong_id)// Fetch item by ID
    {
        for (int i = 0; i < _krathongLog.Count; i++)
        {
            if (_krathongLog[i].krathong_id == krathong_id)
            {
                return _krathongLog[i];
            }
        }
        return null;
    }

    public void FetchKrathongLogs()
    {
        _krathongLog.Clear();
        Debug.Log("Fetch Logs");
        StartCoroutine(GetKrathongLogs(url));
    }
}

[System.Serializable]
// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
public class KrathongLog
{
    [JsonConstructor]
    public KrathongLog(
        string userid,
        string fbname,
        string wish,
        string krathong_id
    )
    {
        this.userid = userid;
        this.fbname = fbname;
        this.wish = wish;
        this.krathong_id = krathong_id;
        this.sprite = Resources.Load<Sprite>("Krathong/" + krathong_id);
    }

    public string userid;
    public string fbname;
    public string wish;
    public string krathong_id;
    public Sprite sprite;

    public KrathongLog()
    {
        this.krathong_id = "-1";
    }
}

