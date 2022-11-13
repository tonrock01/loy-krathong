using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GetUserAccount : MonoBehaviour
{
    [SerializeField]
    private string userId;
    public UserAccount _userAccount = new UserAccount();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetUserAcc("http://103.91.190.179/test_krathong/account_data/"));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetUserAcc(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userId);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            var jsondata = www.downloadHandler.text;
            _userAccount = JsonConvert.DeserializeObject<UserAccount>(jsondata);
            Debug.Log("Form upload complete!");
            //Debug.Log(www.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class UserAccount
{
    public string userid;
    public string fbname;
    public string coins;
    public string cash;
}