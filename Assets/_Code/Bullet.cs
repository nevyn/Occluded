using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	float timeSinceFired = 0.0f;

	// Use this for initialization
	void Start () {
		timeSinceFired = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time - timeSinceFired > 5.0f) {
			Destroy(gameObject);	
		}
	}
	
	void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
		
		//Debug.Log("Collision: " + collision.gameObject.name);
		
		if (collision.gameObject.GetComponent<PlayerHealth>() != null) {
			collision.gameObject.GetComponent<PlayerHealth>().WasHit();
		}
		
		Destroy(gameObject);
    }
}
