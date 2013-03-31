using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	
	public GameObject projectile;
	float fireRate = 0.2f;
    float nextFire = 0.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
		
			nextFire = Time.time + fireRate;
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			GameObject clone = Instantiate(projectile, ray.origin+ray.direction*2.0f, Camera.main.transform.rotation) as GameObject;
 				
    		// Add force to the cloned object in the object's forward direction
   			clone.rigidbody.AddForce(ray.direction * 10.0f);
		}
		
		/*
		if (Input.GetKeyUp(KeyCode.Mouse0)) {
			
			Vector3 mousePos = Input.mousePosition;
			//Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z+Camera.main.nearClipPlane));
			Ray ray = Camera.main.ScreenPointToRay(mousePos);
			
			Vector3 dir = cameraTransform.forward;
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit, 100.0f)) {
				Debug.Log("Hit " + hit.collider.name);
				Debug.DrawRay(ray.origin, ray.direction*100.0f);
				
				if (hit.collider.gameObject.GetComponent<PlayerHealth>() != null) {
					hit.collider.gameObject.GetComponent<PlayerHealth>().WasHit();
				}
			}
		}
		*/
	}
}
