using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Energy")]
public class EnergyBonus : BonusCreator {

	[SerializeField]
    private int energy = 5;

    public override void Use()
    {
        base.Use();
        GameManager.Instance.CurrentPlayer.AddEnergy(energy);
        
        Debug.Log("Dodano 5 punktow energii");
    }
    
}
