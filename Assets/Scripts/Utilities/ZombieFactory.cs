using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class ZombieFactory : Singleton<ZombieFactory>
{

    [SerializeField] private Zombie[] availableZombies;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingZombies = 7;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private List<Zombie> liveZombies = new List<Zombie>();
    private Zombie selectedZombies;
    private PlayerProfile player;

    public List<Zombie> LiveZombies
    {
        get { return liveZombies; }
    }

    public Zombie SelectedZombies
    {
        get { return selectedZombies; }
    }

    private void Awake()
    {
        Assert.IsNotNull(availableZombies);
    }

    void Start()
    {
        player = GameManager.Instance.CurrentPlayer;
        Assert.IsNotNull(player);
        for (int i = 0; i < startingZombies; i++)
        {
            InstantiateZombie();
        }

        StartCoroutine(GenerateZombies());
    }

    public void ZombieWasSelected(Zombie zombie)
    {
        selectedZombies = zombie;
    }

    private IEnumerator GenerateZombies()
    {
        while (true)
        {
            InstantiateZombie();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateZombie()
    {
        int index = Random.Range(0, availableZombies.Length);
        float x = player.transform.position.x + GenerateRange();
        float z = player.transform.position.z + GenerateRange();
        float y = 0;
        liveZombies.Add(Instantiate(availableZombies[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
}

