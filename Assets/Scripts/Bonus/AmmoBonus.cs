using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Ammo" +
    "")]
public class AmmoBonus : BonusCreator {

	[SerializeField]
    private int ammo = 15;

    public override void Use()
    {
        base.Use();
        GameManager.Instance.CurrentPlayer.AddAmmo(ammo);
        
        Debug.Log("Dodano 15 naboi");
    }
    
}
