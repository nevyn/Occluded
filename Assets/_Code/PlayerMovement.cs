using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public GameObject model;
	public GameObject playerController;
	
	bool isMoving = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (networkView.isMine) {
			
			if (playerController.GetComponent<CharacterMotorC>().currentVelocity.x != 0 && playerController.GetComponent<CharacterMotorC>().currentVelocity.z != 0) isMoving = true;
			else isMoving = false;
		}
	
		if (isMoving) {
			if (!model.animation.IsPlaying("walk")) model.animation.CrossFade("walk", 0.2f);	
		}
		else {
			if (!model.animation.IsPlaying("idle")) model.animation.CrossFade("idle", 0.2f);	
		}
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
    	
		if (stream.isWriting) {
        	Vector3 pos = transform.position;
			Quaternion rot = transform.rotation;
        	stream.Serialize(ref pos);
			stream.Serialize(ref rot);
			stream.Serialize(ref isMoving);
		}
		else {
        	Vector3 receivedPosition = Vector3.zero;
			Quaternion receivedRotation = Quaternion.identity;
			bool receivedIsMoving = false;
			
        	stream.Serialize(ref receivedPosition);
			stream.Serialize(ref receivedRotation);
			stream.Serialize(ref receivedIsMoving);
        	transform.position = receivedPosition;
			transform.rotation = receivedRotation;
			isMoving = receivedIsMoving;
		}
	}
}