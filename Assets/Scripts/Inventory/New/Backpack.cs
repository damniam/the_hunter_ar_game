using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{

    #region Singleton

    public static Backpack instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnBonusChanged();
    public OnBonusChanged onBonusChangedCb;
    // Liczba miejsc na przedmioty
    public int slots = 16;
    // Nasza lista przedmiotów w plecaku
    public List<BonusCreator> listBonus = new List<BonusCreator>();
    //Dodaj nowy bonus jesli jest miejsce
    public GameObject noSpaceUI;
    public void Add(BonusCreator bonus)
    {
        if (bonus.showInBackpack)
        {
            if (listBonus.Count >= slots)
            {
                Debug.Log("Brak miejsca");
                //noSpaceUI.SetActive(true);
                return;
            }

            listBonus.Add(bonus);

            if (onBonusChangedCb != null)
                onBonusChangedCb.Invoke();
        }
    }


    public void Remove(BonusCreator bonus)
    {
        listBonus.Remove(bonus);

        if (onBonusChangedCb != null)
            onBonusChangedCb.Invoke();
    }
}

