using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    [SerializeField]
    private Slider energyBar;
    private int energy;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateHpBar();
        energy = Mathf.Clamp(energy, 0, 100);
    }

    private void updateHpBar()
    {
        energyBar.value = GameManager.Instance.CurrentPlayer.Energy;
    }
}