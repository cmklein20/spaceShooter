using UnityEngine;
using System.Collections;

public class Galaxy : MonoBehaviour {
	public float density;
	private float lastTime;
	public GameObject spaceship;
	public GameObject meteorite;

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
			a = (Instantiate(meteorite) as GameObject).GetComponent<Rigidbody>();
			if (a != null) {

				float scale = Random.Range(2.0f, 5.0f);
				a.transform.position = spaceship.transform.position + 100 * spaceship.transform.forward + 500 * Random.onUnitSphere;
				a.velocity = Random.insideUnitSphere * 100;
				a.transform.localScale *= Random.Range(0.8f, 20f);

			}//if
		}
	}
}
