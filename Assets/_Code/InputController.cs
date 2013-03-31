using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	
	public Transform cameraTransform;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}
}
