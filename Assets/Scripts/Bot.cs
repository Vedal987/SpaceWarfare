using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

	public int health;
	public int maxHealth;
	public int damage;

	public GameObject explosion;

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
}
