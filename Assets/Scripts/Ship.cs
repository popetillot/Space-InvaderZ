using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public Transform bulletPrefab;
	private Transform bullet;
	private GUIText livesLabel;
	private float bullettimer;

	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
		bullettimer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bullettimer = bullettimer + Time.deltaTime;
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			if(bullettimer >=0.3f)
			{
				shoot();
				bullettimer = 0f;
			}
		}
	}

	private void shoot()
	{
		bullet = Instantiate(bulletPrefab) as Transform;
		bullet.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		bullet.rigidbody2D.velocity = new Vector2 (0f, 25f);
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
		}
	}
}
