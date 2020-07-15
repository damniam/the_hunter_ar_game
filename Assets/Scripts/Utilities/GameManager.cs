using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	private PlayerProfile currentPlayer;

	public PlayerProfile CurrentPlayer {
		get
		{
			if (currentPlayer == null) {
				currentPlayer = gameObject.AddComponent<PlayerProfile>();
			}
			return currentPlayer;
		}
	}
}
