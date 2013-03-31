using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OccludedPlayer {
	private NetworkPlayer _networkPlayer;

	// Server-side player if _networkPlayer is nil
	public OccludedPlayer() {
	}
	public OccludedPlayer(NetworkPlayer networkPlayer) {
		_networkPlayer = networkPlayer;	
	}
	
	
}


public class NetworkManager : MonoBehaviour {
	private List<OccludedPlayer> _players;
	
	// Use this for initialization
	void Start () {
		_players = new List<OccludedPlayer>();

	}
	
	public void StartServer() {
		Network.InitializeServer(32, 23551, !Network.HavePublicAddress());
		MasterServer.RegisterHost("Occluded", "Test game", "Yay!");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log ("Client connected: " + player.ToString());

		OccludedPlayer newOplayer = new OccludedPlayer(player);
		_players.Add(newOplayer);
		
	}
	
		
	public void OnServerInitialized() {
		Debug.Log ("Server initialized");	
		CreatePlayer();
	}
	
	void OnConnectedToServer() {  
		Debug.Log ("Connected to server");
		CreatePlayer();
	}
	
	public void OnMasterServerEvent(MasterServerEvent evt) {
		if(evt == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Registration succeeeded");
	}
	
	void CreatePlayer() {
		
		GameObject playerController = Instantiate(Resources.Load("Prefabs/PlayerControllerPrefab")) as GameObject;
		GameObject playerModel = Network.Instantiate(Resources.Load("Prefabs/PlayerModelPrefab2"), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), 0) as GameObject;

		playerModel.transform.parent = playerController.transform;
		playerModel.GetComponent<PlayerMovement>().playerController = playerController;
	}
}
