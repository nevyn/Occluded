using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public NetworkManager networkManager;
	
	// Use this for initialization
	void Start () {
		MasterServer.RequestHostList("Occluded");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		if(Network.isClient || Network.isServer)
			return;
		
		Rect pen = new Rect(100, 100, 100, 100);
		if( GUI.Button(pen, "Start server") ) {
			networkManager.StartServer();
		}
		
		pen.y += 120;
		if( GUI.Button (pen, "Refresh") ) {
			MasterServer.RequestHostList("Occluded");	
		}
		
		pen.x = 200;
		pen.y = 100;
		pen.height = 50;
		foreach(HostData hostData in MasterServer.PollHostList()) {
			if( GUI.Button(pen, hostData.gameName) ) {
				Network.Connect(hostData);
			}
			pen.y += 100;
		}
		
	}
	
	public void OnServerInitialized() {
		Debug.Log ("Server initialized");	
	}
	
	public void OnMasterServerEvent(MasterServerEvent evt) {
		if(evt == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Registration succeeeded");
	}
}
