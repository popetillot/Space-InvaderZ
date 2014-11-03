using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float bulletlife;
	// Use this for initialization
	void Start ()
	{
		bulletlife = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{

		bulletlife = bulletlife + Time.deltaTime;
		if (bulletlife >= 2)
		{
			Destroy (this.gameObject);
		}
	}
}
