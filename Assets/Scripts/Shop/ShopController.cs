using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

    public Text moneyAccount;
    public GameObject moneyNeed;
    public GameObject buyInfo;
    public Text buyText;
    // Use this for initialization
    void Start  () {
        
	}
	
	// Update is called once per frame
	void Update () {
        updateMoneyAccout();
		
	}

    public void buyHealth()
    {
        if (GameManager.Instance.CurrentPlayer.Money >= 40)
        {
            GameManager.Instance.CurrentPlayer.AddHp(50);
            GameManager.Instance.CurrentPlayer.TakeMoney(40);
            buyText.text = "First Aid \n+50 Health ";
            buyInfo.SetActive(!buyInfo.activeSelf);
        }
        else if (GameManager.Instance.CurrentPlayer.Money < 40)
        {
            moneyNeed.SetActive(!moneyNeed.activeSelf);
        }
    }

    public void buyEnergy()
    {
        if (GameManager.Instance.CurrentPlayer.Money >= 5)
        {
            GameManager.Instance.CurrentPlayer.AddEnergy(25);
            GameManager.Instance.CurrentPlayer.TakeMoney(5);
            buyText.text = "Cola can \n+25 Energy ";
            buyInfo.SetActive(!buyInfo.activeSelf);
        }
        else if (GameManager.Instance.CurrentPlayer.Money < 5)
        {
            moneyNeed.SetActive(!moneyNeed.activeSelf);
        }
    }

    public void buyFood()
    {
        Debug.Log("button check");
        if (GameManager.Instance.CurrentPlayer.Money >= 15)
        {
            GameManager.Instance.CurrentPlayer.AddFood(30);
            GameManager.Instance.CurrentPlayer.TakeMoney(15);
            Debug.Log("button dds");
            buyText.text = "Hamburger \n+30 Food "; 
            buyInfo.SetActive(!buyInfo.activeSelf);
        }
        else if (GameManager.Instance.CurrentPlayer.Money < 15)
        {
            moneyNeed.SetActive(!moneyNeed.activeSelf);
        }
    }

    public void buyAmmo()
    {
        if (GameManager.Instance.CurrentPlayer.Money >= 60)
        {
            GameManager.Instance.CurrentPlayer.AddAmmo(30);
            GameManager.Instance.CurrentPlayer.TakeMoney(60);
            buyText.text = "Ammunition \n+30 Ammo ";
            buyInfo.SetActive(!buyInfo.activeSelf);
        }
        else if (GameManager.Instance.CurrentPlayer.Money < 60)
        {
            moneyNeed.SetActive(!moneyNeed.activeSelf);
        }
    }

    void updateMoneyAccout()
    {
        moneyAccount.text = GameManager.Instance.CurrentPlayer.Money.ToString() + " $";
    }


}
