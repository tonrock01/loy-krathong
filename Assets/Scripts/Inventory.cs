using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPanel;
    KrathongList krathongdatabase;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public List<Krathong> items = new List<Krathong>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        krathongdatabase = GetComponent<KrathongList>();
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;
        for (int i = 0; i < krathongdatabase._krathongList.Count; i++)
        {
            items.Add(new Krathong());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            AddItem(i + 1);
        }

    }

    public void AddItem(int id)
    {
        Krathong itemToAdd = krathongdatabase.FetchKrathongByID(id.ToString());
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].krathong_id == "-1")
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                // itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                itemObj.name = itemToAdd.krathong_id;
                itemObj.GetComponentInChildren<Text>().text = itemToAdd.price;
                itemObj.GetComponentInChildren<TMP_Text>().text = itemToAdd.price_type;
                break;
            }
        }
    }
    
    public void RefreshSlot()
    {
        for (int i = 0; i < krathongdatabase._krathongList.Count; i++)
        {
            items.Add(new Krathong());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            Debug.Log(i);
            AddItem(i + 1);
        }
    }
}
