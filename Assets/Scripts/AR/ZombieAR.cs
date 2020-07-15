using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAR : MonoBehaviour {

    [SerializeField]
    public float zombieHP = 105f;
    public bool collisionPlayer;
    private float timer;
    private int waitTime = 2;


    AudioSource shootBloodSound;
    AudioSource attackSound;
    
    private GameControllerScript gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerScript>();
        }

        // AudioSource[] audios = GetComponents<AudioSource>();
        // attackSound = audios[0];
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (collisionPlayer && timer >= waitTime)
        {
            Attack();
        }
    }

    public void TakeDamage(float damage)
    {
       // bloodSound.Play();
       
        zombieHP -= damage;
        Debug.Log(zombieHP);
        if (zombieHP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, 0.2f);
        GameManager.Instance.CurrentPlayer.AddXp(25);
        GameManager.Instance.CurrentPlayer.AddKilledZombies(gameObject);
        
    }

    void Attack()
    {
        timer = 0f;
        GetComponent<Animator>().SetTrigger("attack");
        gameController.zombieAttack(collisionPlayer);
        attackSound.Play();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            collisionPlayer = true;

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            collisionPlayer = false;
        }
    }
}
