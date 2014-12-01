using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

		if(Input.GetKey(KeyCode.A)){
			//Debug.Log("Pushing left");
			transform.Rotate(Vector3.down * (speed * 10) * Time.deltaTime);	
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up * (speed * 10) * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Rotate(Vector3.left * (speed * 10) * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Rotate(Vector3.right * (speed * 10) * Time.deltaTime);
		}
		//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (5 * Time.deltaTime) );
	}
}
