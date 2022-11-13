using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class SubmitKrathong : MonoBehaviour
{
    private string url = "http://103.91.190.179/test_krathong/krathong_submit/";
    [SerializeField]
    public string _userID;
    [SerializeField]
    public string _krathongId;
    public InputField wishbox;
    SpawnKrathong _spawnkrathong;
    public KrathongList _price;
    public ErrorMessage _errormess = new ErrorMessage();

    public GameObject YesNoPanel;
    public GameObject ErrorPanel;
    public Text Errortext;
    public Text PriceType;
    public Text Price;
    // Start is called before the first frame update
    void Start()
    {
        _spawnkrathong = GetComponent<SpawnKrathong>();
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
                var errordata = www.downloadHandler.text;
                _errormess = JsonConvert.DeserializeObject<ErrorMessage>(errordata);
                ErrorPanel.SetActive(true);
                UpdateErrorMess();

            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                _spawnkrathong.UserSpawnKrathong();
                wishbox.text = "";
            }
        }
    }

    [ContextMenu("SubmitData")]
    public void SubmitData()
    {
        StartCoroutine(LoyKrathong());
    }

    public void SureToPay()
    {
        YesNoPanel.SetActive(true);
        UpdatePrice();
    }

    public void UpdateErrorMess()
    {
        if (_errormess.errors == "max_floating_reached")
        {
            Errortext.text = "ลอยกระทงนี้ไปแล้ว สามารถลอยกระทงนี้ได้ 1 ครั้ง";
        }
        if (_errormess.errors == "not_enough_coins")
        {
            Errortext.text = "เหรียญของคุณคงเหลือไม่พอ";
        }
        if (_errormess.errors == "not_enough_cash")
        {
            Errortext.text = "เงินของคุณคงเหลือไม่พอ";
        }
    }

    public void UpdatePrice()
    {
        if (_krathongId == "1")
        {
            Price.text = _price._krathongList[0].price;
            PriceType.text = _price._krathongList[0].price_type;
        }
        if (_krathongId == "2")
        {
            Price.text = _price._krathongList[1].price;
            PriceType.text = _price._krathongList[1].price_type;
        }
        if (_krathongId == "3")
        {
            Price.text = _price._krathongList[2].price;
            PriceType.text = _price._krathongList[2].price_type;
        }
        if (_krathongId == "4")
        {
            Price.text = _price._krathongList[3].price;
            PriceType.text = _price._krathongList[3].price_type;
        }
        if (_krathongId == "5")
        {
            Price.text = _price._krathongList[4].price;
            PriceType.text = _price._krathongList[4].price_type;
        }
        if (_krathongId == "6")
        {
            Price.text = _price._krathongList[5].price;
            PriceType.text = _price._krathongList[5].price_type;
        }
        if (_krathongId == "7")
        {
            Price.text = _price._krathongList[6].price;
            PriceType.text = _price._krathongList[6].price_type;
        }
    }
}

[System.Serializable]
public class ErrorMessage
{
    public int code;
    public string errors;
}
