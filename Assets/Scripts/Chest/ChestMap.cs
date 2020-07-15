using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMap : MonoBehaviour {



    private void OnMouseDown()
    {
        TheHuntSceneManager[] chests = FindObjectsOfType<TheHuntSceneManager>();
        foreach (TheHuntSceneManager theHuntSceneManager in chests)
        {
            if (theHuntSceneManager.gameObject.activeSelf)
            {
                theHuntSceneManager.chestTapped(this.gameObject);
            }
        }
    }


}
