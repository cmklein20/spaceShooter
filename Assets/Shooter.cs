using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile;
	public GameObject camera;
	public AudioClip shoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 direction = transform.forward;
			Rigidbody proj = (Instantiate(projectile) as GameObject).GetComponent<Rigidbody>();
			proj.transform.position = transform.position + direction * 3;
			proj.AddForce(ray.direction * 15000);
			camera.audio.PlayOneShot(shoot);
		}
	}
}
