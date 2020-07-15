using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBonus", menuName = "Inventory/Bonus")]
public class BonusCreator : ScriptableObject {

    new public string name = "New Bonus";
    public Sprite image = null;
    public bool showInBackpack = true;

	public virtual void Use()
    {
        Debug.Log("Metoda do nadpisania");

    }
}
