using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollect : MonoBehaviour {

	[SerializeField] private int cash = 10;

	private void OnMouseDown() {
		GameManager.Instance.CurrentPlayer.AddMoney(cash);
		Destroy(gameObject);
	}
}
