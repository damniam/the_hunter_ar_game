using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{

    [SerializeField]
    private int xp = 0;
    [SerializeField]
    private int requiredXp = 100;
    [SerializeField]
    private int energy = 100;
    [SerializeField]
    private int hp = 100;
    [SerializeField]
    private int food = 100;
    [SerializeField]
    private int levelBase = 100;
    [SerializeField]
    private int ammoAmount = 90;
    [SerializeField]
    private int survivedDays = 0;
    [SerializeField]
    private int money = 100;
    private List<GameObject> zombies = new List<GameObject>();
    private string nickname = "Damian";
    private int lvl = 1;
    private string path;

    public int Lvl
    {
        get { return lvl; }
    }
    public int Xp
    {
        get { return xp; }
    }
    public int RequiredXp
    {
        get { return requiredXp; }
    }
    public int Hp
    {
        get { return hp; }
    }
    public int Energy
    {
        get { return energy; }
    }
    public int Food
    {
        get { return food; }
    }
    public int LevelBase
    {
        get { return levelBase; }
    }
    public int Ammo
    {
        get { return ammoAmount; }
    }
    public int SurvivedDays
    {
        get { return survivedDays; }
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }
    public List<GameObject> Zombie
    {
        get { return zombies; }
    }
    public string Nickname
    {
        get { return nickname; }
    }


    private void Start()
    {
        path = Application.persistentDataPath + "/player.dat";
        Load();
    }

    public void AddXp(int xp)
    {
        this.xp += Mathf.Max(0, xp);
        InitLevelData();
        Save();
    }
    public void AddHp(int hp)
    {
        this.hp += Mathf.Max(0, hp);
        Save();
    }
    public void TakeHp(int hp)
    {
        this.hp -= hp;
        Save();
    }
    public void AddEnergy(int energy)
    {
        this.energy += Mathf.Max(0, energy);
        Save();
    }
    public void AddFood(int food)
    {
        this.food += Mathf.Max(0, food);
        Save();
    }
    public void AddAmmo(int ammo)
    {
        this.ammoAmount += Mathf.Max(0, ammo);
        Save();
    }
    public void SetSurvivedDays(int days)
    {
        this.survivedDays += days;
        TakeFood(10);
    }
    public void TakeFood(int food)
    {
        if(this.food > 0)
        {
            this.food -= food;
        }
        else if(this.food<= 0)
        {
            if(this.energy > 0)
            {
                this.energy -= food;
            }
            else if(energy<=0)
            {
                this.hp -= food;
            }
        }
        Save();
    }
    public void AddMoney(int money)
    {
        this.money += money;
        Save();
    }
    public void TakeMoney(int money)
    {
        this.money -= money;
        Debug.Log("Mała mała tyle mam siana " + this.money);
        Save();
    }
    public void AddKilledZombies(GameObject zombie)
    {
        if (zombie)
            zombies.Add(zombie);

    }
    public void SetNickname(string nick)
    {
        this.nickname = nick;
        Save();
    }
    private void InitLevelData()
    {
        lvl = (xp / levelBase) + 1;
        requiredXp = levelBase * lvl;
    }

    private void OnMouseDown()
    {
        TheHuntSceneManager player = FindObjectOfType<TheHuntSceneManager>();
            if (player.gameObject.activeSelf)
            {
                player.playerTapped(this.gameObject);
            }
        
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerProfileData data = new PlayerProfileData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerProfileData data = (PlayerProfileData)bf.Deserialize(file);
            file.Close();

            xp = data.Xp;
            requiredXp = data.RequiredXp;
            levelBase = data.LevelBase;
            zombies = data.Zombies;
            lvl = data.Lvl;
             food = data.Food;
            hp = data.Hp;
            energy = data.Energy;

        }
        else
        {
            InitLevelData();
        }

    }
}

[Serializable]
internal class PlayerProfileData
{
    private int xp = 0;
    private int requiredXp = 100;
    private int levelBase = 100;
    private int hp = 100;
    private int energy = 100;
    private int food = 100;
    private List<GameObject> zombies = new List<GameObject>();
    private int lvl = 1;
    private int survivedDays = 0;
    private int ammo = 90;

    public int Xp { get { return xp; } }
    public int RequiredXp { get { return requiredXp; } }
    public int LevelBase { get { return levelBase; } }
    public List<GameObject> Zombies { get { return zombies; } }
    public int Lvl { get { return lvl; } }
    public int Energy { get { return energy; } }
    public int Food { get { return food; } }
    public int Hp { get { return hp; } }
    public int SurvivedDays { get { return survivedDays; } }


    public PlayerProfileData(PlayerProfile player)
    {
        xp = player.Xp;
        requiredXp = player.RequiredXp;
        levelBase = player.LevelBase;
        lvl = player.Lvl;
        hp = player.Hp;
        energy = player.Energy;
        food = player.Food;
        zombies = player.Zombie;
    }
}