using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{

    [SerializeField]
    private Slider foodBar;
    private int food;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateHpBar();
        food = Mathf.Clamp(food, 0, 100);
    }

    private void updateHpBar()
    {
        foodBar.value = GameManager.Instance.CurrentPlayer.Food;
    }
}