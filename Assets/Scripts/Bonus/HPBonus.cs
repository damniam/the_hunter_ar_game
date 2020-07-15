using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Health")]
public class HPBonus : BonusCreator {

	[SerializeField]
    private int health = 5;

    public override void Use()
    {
        base.Use();
        GameManager.Instance.CurrentPlayer.AddHp(health);
        
        Debug.Log("Dodano 5hp");
    }
    
}
