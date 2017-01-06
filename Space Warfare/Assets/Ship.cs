using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Rigidbody rigidbody;

	public GameObject camera;

	float vertical;

	public float acceleration;
	public float speed;
	public float maxSpeed;
	public float minSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis ("Vertical");

		if (vertical > 0.1 && speed <= maxSpeed) {
			speed += Time.deltaTime * acceleration;
		} else if (vertical < 0 && speed >= minSpeed) {
			speed -= Time.deltaTime * acceleration;
		}
		if (vertical == 0 && speed < 0) {
			speed += Time.deltaTime * 5;
		}
		if (vertical == 0 && speed > 0) {
			speed -= Time.deltaTime * 5;
		}

		camera.GetComponent<Camera> ().fieldOfView = 60 + (speed * 2);
		if (camera.GetComponent<Camera> ().fieldOfView > 70) {
			camera.GetComponent<Camera> ().fieldOfView = 70;
		}
		if (camera.GetComponent<Camera> ().fieldOfView < 50) {
			camera.GetComponent<Camera> ().fieldOfView = 50;
		}
	}

	void FixedUpdate()
	{
		rigidbody.AddForce (transform.forward * speed, ForceMode.VelocityChange);
	}
}
