using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKrathong : MonoBehaviour
{
    public string krathongID;
    public SubmitKrathong _submitKrathong;
    // Start is called before the first frame update
    void Start()
    {
        krathongID = this.gameObject.name;
        _submitKrathong = FindObjectOfType<SubmitKrathong>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChooseKrathong()
    {
        GameObject.Find("WhatKrathong").GetComponent<Image>().sprite = Resources.Load<Sprite>("Krathong/" + krathongID);
        _submitKrathong._krathongId = krathongID;
    }
}
