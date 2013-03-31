using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	float health = 100.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void WasHit() {
		
		Debug.Log("Was hit!");
		networkView.RPC("TakeDamage", RPCMode.All, 25.0f);
	}
	
	[RPC]
	void TakeDamage(float damage) {
		health -= damage;
	}
	
	void OnGUI() {
		if (networkView.isMine) {
			GUI.Label(new Rect(10, 10, 100, 50), "Health: " + health);	
		}
	}
}
