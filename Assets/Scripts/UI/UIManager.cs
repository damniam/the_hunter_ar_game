using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private InputField nickname;
    [SerializeField] private Button setNickname;
    [SerializeField] private Text levelText;
    [SerializeField] private Text xpText;
    [SerializeField] private Text requiredXpText;
    [SerializeField] private Text XPlevel;
    [SerializeField] private Text foodText;
    [SerializeField] private Text hpText;
    [SerializeField] private Text energyText;
    [SerializeField] private Text ammoText;
    [SerializeField] private Text cashText;
    [SerializeField] private Text survivedDays;
    [SerializeField] private Text killedZombie;
    //[SerializeField] private Slider healthSlider;
    //[SerializeField] private Slider energySlider;
    //[SerializeField] private Slider foodSlider;

    public float health;
    public float minH;
    public float maxH;
	
    private void Start()
    {
    
    }


    private void Update() {
		updateLevel();
	    updateXP();
        updateEnergy();
        updateFood();
        updateHealth();
        updateAmmo();
        updateCash();
        updateSurvivedDays();
        updateZombieKilled();
        updateXPLevel();

	}

    public void updateXPLevel()
    {
        XPlevel.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
    }

    void updateHealth()
    {
        hpText.text = GameManager.Instance.CurrentPlayer.Hp.ToString();
    }
    public void updateEnergy()
    {
        energyText.text = GameManager.Instance.CurrentPlayer.Energy.ToString();
    }
    public void updateFood()
    {
        foodText.text = GameManager.Instance.CurrentPlayer.Food.ToString();
    }
    public void updateLevel() {
		levelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
	}
	public void updateXP() {
		xpText.text = GameManager.Instance.CurrentPlayer.Xp +" / " + GameManager.Instance.CurrentPlayer.RequiredXp;
	}
    public void updateCash()
    {
        cashText.text = GameManager.Instance.CurrentPlayer.Money.ToString() + " $";
    }
    public void updateAmmo()
    {
        ammoText.text = GameManager.Instance.CurrentPlayer.Ammo.ToString();
    }
    public void updateSurvivedDays()
    {
        survivedDays.text = GameManager.Instance.CurrentPlayer.SurvivedDays.ToString();
    }
    public void updateZombieKilled()
    {
        killedZombie.text = GameManager.Instance.CurrentPlayer.Zombie.Count.ToString();
    }
    

}
