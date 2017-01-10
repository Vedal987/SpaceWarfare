using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

	public int health;
	public int maxHealth;
	public int damage;

	public GameObject explosion;

	public GameObject muzzle;
	public GameObject muzzleParticles;
	public GameObject muzzleFlash;
	public GameObject laser;

	public AudioClip laserSFX;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Damage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			Instantiate (explosion, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
		

	IEnumerator Shoot()
	{
		muzzleParticles.GetComponent<ParticleEmitter> ().Emit ();
		muzzleFlash.SetActive (true);
		this.GetComponent<AudioSource> ().PlayOneShot (laserSFX);
		Instantiate (laser, muzzleFlash.transform.position, muzzleFlash.transform.rotation);
		Raycast ();
		yield return new WaitForSeconds(0.10f);
		muzzleFlash.SetActive (false);
	}

	void Raycast()
	{
		RaycastHit hit;
		Vector3 direction = muzzle.transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (muzzle.transform.position, direction, out hit, 20000)) {
			if (hit.collider.transform.tag == "Player") {
				hit.collider.transform.SendMessage ("Damage", damage);
			}
		}
	}
}
