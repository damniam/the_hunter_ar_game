using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Food")]
public class FoodBonus : BonusCreator {

	[SerializeField]
    private int food = 10;

    public override void Use()
    {
        base.Use();
        GameManager.Instance.CurrentPlayer.AddFood(food);
        
        Debug.Log("Dodano 10 punktow jedzenia");
    }
    
}
