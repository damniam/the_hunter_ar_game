using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBonus : Active {

    public BonusCreator bonus;
    public override void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Backpack.instance.Add(bonus);
            Destroy(gameObject);
        }
    }

}
