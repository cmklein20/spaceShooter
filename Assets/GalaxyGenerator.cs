using UnityEngine;
using System.Collections;

public class GalaxyGenerator : MonoBehaviour {
	public float density;
	private float lastTime;
	public GameObject spaceship;
	public GameObject galaxy;
	public Rigidbody a;

	public float xDif;
	public float yDif;
	public Vector2 Playerdirection;
	public float speed;

	// Update is called once per frame
	void Update () {
		float dt = Time.time - lastTime;
		if (Random.value < density * dt) {
			if (galaxy != null) {
				a = (Instantiate(galaxy) as GameObject).GetComponent<Rigidbody>();
				if (GameObject.FindGameObjectWithTag("MainCamera").rigidbody.position.x < 100) {
					xDif = spaceship.rigidbody.position.x - transform.position.x;
					yDif = spaceship.rigidbody.position.y - transform.position.y;
					if (xDif < 2 && xDif > 0 && yDif < 2 && yDif > 0) {
						Playerdirection = new Vector2 (xDif, -yDif);
						rigidbody.AddForce(Playerdirection.normalized * speed);
					}//if
				}//if
			}//if
		}//if

	}//update
}
