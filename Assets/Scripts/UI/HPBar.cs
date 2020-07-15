using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    [SerializeField]
    private Slider hpBar;
    private int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateHpBar();
        health = Mathf.Clamp(health, 0, 100);
	}

    private void updateHpBar()
    {
        hpBar.value = GameManager.Instance.CurrentPlayer.Hp;
    }
}
