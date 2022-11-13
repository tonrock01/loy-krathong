using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SubmitKrathong : MonoBehaviour
{
    private string url = "http://103.91.190.179/test_krathong/krathong_submit/";
    [SerializeField]
    public string _userID;
    [SerializeField]
    public string _krathongId;
    public InputField wishbox;
    public Button loykrathongBT;
    SpawnKrathong _spawnkrathong;
    // Start is called before the first frame update
    void Start()
    {
        _spawnkrathong = GetComponent<SpawnKrathong>();
        //wishbox = GameObject.Find("WishBox").GetComponent<InputField>();
        //loykrathongBT.onClick.AddListener(SubmitData);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator LoyKrathong()
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", _userID);
        form.AddField("krathong_id", _krathongId);
        form.AddField("wish", wishbox.text);
        

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                // Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                _spawnkrathong.UserSpawnKrathong();
            }
        }
    }

    [ContextMenu("SubmitData")]
    public void SubmitData()
    {
        StartCoroutine(LoyKrathong());
    }
}
