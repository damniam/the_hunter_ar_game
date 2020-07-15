using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : TheHuntSceneManager {

    private GameObject player;
    private GameObject zombie;
    private GameObject chest;

	private AsyncOperation loadScene;

    public override void chestTapped(GameObject chest)
    {
        SceneManager.LoadScene(ZombieConstants.CHEST_COLLECT);
    }

    public override void playerTapped(GameObject player)
    {
        Debug.Log("Dotkniecie playera ");
	}

	public override void zombieTapped(GameObject zombie) {
    	SceneManager.LoadScene(ZombieConstants.SCENE_FIGHT);
		List<GameObject> objects = new List<GameObject>();
		objects.Add(zombie);
		SceneTransitionManager.Instance.GoToScene(ZombieConstants.SCENE_FIGHT, objects);
	}
}
