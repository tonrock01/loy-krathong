using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnKrathong : MonoBehaviour
{
    public GameObject krathongObject;
    public GameObject[] spawnpoints;
    KrathongLogs _krathonglogs;
    SubmitKrathong _submitkrathong;
    public float delayDeploy;
    public int CountKrathong;
    public float delayFetch;
    // Start is called before the first frame update
    void Start()
    {
        _krathonglogs = GetComponent<KrathongLogs>();
        _submitkrathong = GetComponent<SubmitKrathong>();
        SpawnKrathongFuction(delayDeploy);
    }

    // Update is called once per frame
    void Update()
    {
        if (CountKrathong == -1)
        {
            StartCoroutine(FetchDelay(delayFetch));
        }
    }

    void SpawnKrathongFuction(float delayTime)
    {
        StartCoroutine(Spawn(delayTime));
    }

    IEnumerator Spawn(float delayTime)
    {
        for (CountKrathong = 0; CountKrathong < _krathonglogs._krathongLog.Count; CountKrathong++)
        {
            int sp = Random.Range(0, 3);
            yield return new WaitForSeconds(delayTime);
            GameObject krathongObj = GameObject.Instantiate(krathongObject, spawnpoints[sp].transform.position, Quaternion.identity);
            krathongObj.GetComponent<SpriteRenderer>().sprite = _krathonglogs._krathongLog[CountKrathong].sprite;
            krathongObj.name = _krathonglogs._krathongLog[CountKrathong].userid;
            krathongObj.GetComponentInChildren<Text>().text = _krathonglogs._krathongLog[CountKrathong].wish;
            krathongObj.GetComponentInChildren<TMP_Text>().text = _krathonglogs._krathongLog[CountKrathong].fbname;
        }
        CountKrathong = -1;
    }

    IEnumerator FetchDelay(float delayFetchTime)
    {
        CountKrathong = 0;
        Debug.Log("enter");
        _krathonglogs.FetchKrathongLogs();
        yield return new WaitForSeconds(delayFetchTime);
        SpawnKrathongFuction(delayDeploy);

    }

    public void UserSpawnKrathong()
    {
        int sp = Random.Range(0, 3);
        GameObject userkrathongObj = GameObject.Instantiate(krathongObject, spawnpoints[sp].transform.position, Quaternion.identity);
        if (_submitkrathong._krathongId == "1")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "1");
        }
        if (_submitkrathong._krathongId == "2")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "2");
        }
        if (_submitkrathong._krathongId == "3")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "3");
        }
        if (_submitkrathong._krathongId == "4")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "4");
        }
        if (_submitkrathong._krathongId == "5")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "5");
        }
        if (_submitkrathong._krathongId == "6")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "6");
        }
        if (_submitkrathong._krathongId == "7")
        {
            userkrathongObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Krathong/" + "7");
        }
        userkrathongObj.name = _submitkrathong._userID;
        userkrathongObj.GetComponentInChildren<Text>().text = _submitkrathong.wishbox.text;
        userkrathongObj.GetComponentInChildren<TMP_Text>().text = _submitkrathong._userID;
    }

}
