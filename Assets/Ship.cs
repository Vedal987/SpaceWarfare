using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Rigidbody rigidbody;

	public GameObject camera;

	float vertical;
	float roll;

	public float acceleration;
	public float thrust;
	public float maxThrust;
	public float minThrust;

	public int health;
	public int maxHealth;

	public float timeBetweenShot;

	public GameObject muzzleParticles;
	public GameObject muzzleFlash;
	public GameObject laser;


	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		vertical = Input.GetAxis ("Vertical");
		roll = Input.GetAxis ("Roll");

		if (vertical > 0.1 && thrust <= maxThrust) {
			thrust += Time.deltaTime * acceleration;
		} else if (vertical < 0 && thrust >= minThrust) {
			thrust -= Time.deltaTime * acceleration;
		}
		if (vertical == 0 && thrust < 0) {
			thrust += Time.deltaTime * 5;
		}
		if (vertical == 0 && thrust > 0) {
			thrust -= Time.deltaTime * 5;
		}

		if (timeBetweenShot <= 0 && Input.GetMouseButton(0)) {
			timeBetweenShot = 0.2f;
			StartCoroutine (Shoot ());
		}

		timeBetweenShot -= Time.deltaTime;

		//this.transform.Rotate(Vector3.forward * (roll * 180));

		camera.GetComponent<Camera> ().fieldOfView = 60 + (thrust * 2);
		if (camera.GetComponent<Camera> ().fieldOfView > 70) {
			camera.GetComponent<Camera> ().fieldOfView = 70;
		}
		if (camera.GetComponent<Camera> ().fieldOfView < 50) {
			camera.GetComponent<Camera> ().fieldOfView = 50;
		}
	}

	void FixedUpdate()
	{
		rigidbody.AddForce (transform.forward * thrust, ForceMode.VelocityChange);
	}

	IEnumerator Shoot()
	{
		muzzleParticles.GetComponent<ParticleEmitter> ().Emit ();
		muzzleFlash.SetActive (true);
		Instantiate (laser, muzzleFlash.transform.position, muzzleFlash.transform.rotation);
		yield return new WaitForSeconds(0.10f);
		muzzleFlash.SetActive (false);
	}
}
