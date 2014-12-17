using UnityEngine;
using System.Collections;

public class AsteroidGenerator : MonoBehaviour {
	public float density;
	private float lastTime;
	public GameObject spaceship;
	public GameObject asteroid;
	public GameObject asteroid2;
	public GameObject asteroid3;
	public GameObject fuelroid;
	public bool refuelAvailable;
	public bool multipleAsteroids;
	// Use this for initialization
	void Start () {
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		float dt = Time.time - lastTime;
		lastTime = Time.time;

		if (Random.value < density*dt) {
			float f = Random.value;
			Rigidbody a;
			if(refuelAvailable && f < .02){
				a = (Instantiate(fuelroid) as GameObject).GetComponent<Rigidbody>();
				a.transform.localScale *= 50;
			}else if(multipleAsteroids && f < 0.3){
				a = (Instantiate(asteroid2) as GameObject).GetComponent<Rigidbody>();
				float scale = Random.Range(1.0f, 5.0f);
				a.transform.localScale *= Random.Range(50f, 75f);
			}else if(multipleAsteroids && f < 0.6)
			{
				a = (Instantiate(asteroid3) as GameObject).GetComponent<Rigidbody>();
				float scale = Random.Range(1.0f, 5.0f);
				a.transform.localScale *= Random.Range(15f, 30f);

			}else{
				a = (Instantiate(asteroid) as GameObject).GetComponent<Rigidbody>();
				float scale = Random.Range(1.0f, 5.0f);
				a.transform.localScale *= Random.Range(0.8f, 20f);
			}
			a.transform.position = spaceship.transform.position + 1000 * spaceship.transform.forward + 600 * Random.onUnitSphere;
			a.velocity = Random.insideUnitSphere * 100;


		}
	}
}
