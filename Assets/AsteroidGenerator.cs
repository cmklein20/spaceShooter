using UnityEngine;
using System.Collections;

public class AsteroidGenerator : MonoBehaviour {
	public float density;
	private float lastTime;
	public GameObject spaceship;
	public GameObject asteroid;
	// Use this for initialization
	void Start () {
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.time - lastTime;
		lastTime = Time.time;
		if (Random.value < density*dt) {	
			Rigidbody a;

			a = (Instantiate(asteroid) as GameObject).GetComponent<Rigidbody>();
			float scale = Random.Range(1.0f, 5.0f);

			a.transform.position = spaceship.transform.position + 1000 * spaceship.transform.forward + 600 * Random.onUnitSphere;
			a.velocity = Random.insideUnitSphere * 100;
			a.transform.localScale *= Random.Range(0.8f, 20f);

		}
	}
}
