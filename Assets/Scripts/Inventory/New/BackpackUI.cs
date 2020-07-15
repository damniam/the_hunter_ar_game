using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : MonoBehaviour {

    public GameObject backpackUI;
    //Rodzic wszystkich bonusów
    public Transform bonusParent;

    Backpack backpack;
    BackpackSlot[] slots;

    void Start()
    {
        backpack = Backpack.instance;
        backpack.onBonusChangedCb += UpdateUI;
        slots  = bonusParent.GetComponentsInChildren<BackpackSlot>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            backpackUI.SetActive(!backpackUI.activeSelf);
            UpdateUI();
        }
        
    }


    // Aktualizowanie UI plecaka poprzez dodawanie przedmiotów, 
    public void UpdateUI()
    {

        BackpackSlot[] itemsSlots = GetComponentsInChildren<BackpackSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < backpack.listBonus.Count)
            {
                slots[i].AddItem(backpack.listBonus[i]);
                Debug.Log("Check");
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
}
