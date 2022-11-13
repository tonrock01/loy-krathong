using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectKrathong : MonoBehaviour
{
    public string krathongID;
    // Start is called before the first frame update
    void Start()
    {
        krathongID = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChooseKrathong()
    {
        GameObject.Find("WhatKrathong").GetComponent<Image>().sprite = Resources.Load<Sprite>("Krathong/" + krathongID); 
    }
}
