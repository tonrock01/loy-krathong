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
    public float delayDeploy;
    public int CountKrathong;
    public float delayFetch;
    // Start is called before the first frame update
    void Start()
    {
        _krathonglogs = GetComponent<KrathongLogs>();
        SpawnKrathongFuction(delayDeploy);
        // for (int i = 0; i < _krathonglogs._krathongLog.Count; i++)
        // {
        //     int sp = Random.Range(0, 3);
        //     GameObject krathongObj = GameObject.Instantiate(krathongObject, spawnpoints[sp].transform.position, Quaternion.identity);
        //     krathongObj.GetComponent<SpriteRenderer>().sprite = _krathonglogs._krathongLog[i].sprite;
        //     krathongObj.name = _krathonglogs._krathongLog[i].userid;
        //     krathongObj.GetComponentInChildren<Text>().text = _krathonglogs._krathongLog[i].wish;
        //     krathongObj.GetComponentInChildren<TMP_Text>().text = _krathonglogs._krathongLog[i].fbname;
        // }
        // if (countkra < _krathonglogs._krathongLog.Count)
        // {
        //     int sp = Random.Range(0, 3);
        //     GameObject krathongObj = GameObject.Instantiate(krathongObject, spawnpoints[sp].transform.position, Quaternion.identity);
        //     krathongObj.GetComponent<SpriteRenderer>().sprite = _krathonglogs._krathongLog[countkra].sprite;
        //     krathongObj.name = _krathonglogs._krathongLog[countkra].userid;
        //     krathongObj.GetComponentInChildren<Text>().text = _krathonglogs._krathongLog[countkra].wish;
        //     krathongObj.GetComponentInChildren<TMP_Text>().text = _krathonglogs._krathongLog[countkra].fbname;
        //     countkra++;
        // }
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
}
