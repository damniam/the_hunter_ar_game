using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public GameObject hurtScreen;
    public GameObject instructionUI;

    // Update is called once per frame
    private void Start()
    {
        instructionUI.SetActive(true);
        StartCoroutine(wait5seconds());
    }


    void Update()
    {

        if (GameManager.Instance.CurrentPlayer.Hp <= 0)
        {
            PlayerDead();
        }

    }

    public void zombieAttack(bool zombieIsThere)
    {
        hurtScreen.gameObject.SetActive(!hurtScreen.activeSelf);
        StartCoroutine(wait2seconds());
        GameManager.Instance.CurrentPlayer.TakeHp(5);

    }

    IEnumerator wait2seconds()
    {
        yield return new WaitForSeconds(2f);
        hurtScreen.gameObject.SetActive(!hurtScreen.activeSelf);
    }

    IEnumerator wait5seconds()
    {
        yield return new WaitForSeconds(5f);
        instructionUI.SetActive(false);
    }

    public void Return()
    {
        SceneManager.LoadScene("World");
    }

    private void PlayerDead()
    {
        SceneManager.LoadScene("Dead");
    }
}
