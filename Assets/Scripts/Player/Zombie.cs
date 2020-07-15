using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.10f;
     
    //[SerializeField] private AudioClip crySound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
      //  Assert.IsNotNull(audioSource);
      //  Assert.IsNotNull(crySound);
    }

   
    public float SpawnRate
    {
        get { return spawnRate; }
    }

    private void OnMouseDown()
    {
        TheHuntSceneManager[] managers = FindObjectsOfType<TheHuntSceneManager>();
        foreach (TheHuntSceneManager theHuntSceneManager in managers)
        {
            if (theHuntSceneManager.gameObject.activeSelf)
            {
                theHuntSceneManager.zombieTapped(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        TheHuntSceneManager[] managers = FindObjectsOfType<TheHuntSceneManager>();
        foreach (TheHuntSceneManager theHuntSceneManager in managers)
        {
            if (theHuntSceneManager.gameObject.activeSelf)
            {
                theHuntSceneManager.zombieCollision(this.gameObject, other);
            }
        }
    }
}
