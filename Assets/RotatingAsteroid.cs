using UnityEngine;
using System.Collections;

public class RotatingAsteroid : MonoBehaviour {
	public float speed = 0f;
	public GameObject explosion;
	public GameObject spaceShip;
	// Use this for initialization

	void Start () {

		spaceShip = GameObject.Find("Main Camera");
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * 3;
	}

	// Update is called once per frame
	void Update () {
		if ((transform.position - spaceShip.transform.position).magnitude > 8000) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(this.gameObject);

//		Debug.Log("Collision " + (transform.position - spaceShip.transform.position).magnitude);
	}

}
