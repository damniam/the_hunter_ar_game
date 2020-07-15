using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSlot : MonoBehaviour {

    public Button removeButton;
    public Image image;
    BonusCreator bonus;

    public void AddItem(BonusCreator newItem)
    {
        bonus = newItem;
        image.sprite = bonus.image;
        image.enabled = true;
        removeButton.interactable = true;
        
    }

    public void UseBonus()
    {
        if (bonus != null)
        {
          bonus.Use();
            Backpack.instance.Remove(bonus);
        }
    }

    // Jeśli naciśniemy przycisk usuwający, ta funkcja zostanie wywołana
    public void RemoveItem()
    {
        Backpack.instance.Remove(bonus);
    }

    public void Clear()
    {
        bonus = null;
        image.sprite = null;
        image.enabled = false;
        removeButton.interactable = false;
    }

}
