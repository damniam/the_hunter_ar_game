using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TheHuntSceneManager : MonoBehaviour {

    public abstract void playerTapped(GameObject player);
    public abstract void zombieTapped(GameObject zombie);
    public abstract void chestTapped(GameObject chest);

    public virtual void zombieCollision(GameObject zombie, Collision other) { }
}
