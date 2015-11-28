using UnityEngine;
using System.Collections;

public class laserMovement : MonoBehaviour {

	public float speed = 10f;

	float ymin;
	float ymax;
	float padding;

	void Start ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		
		Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 uppermost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		
		// Pad the value by 1/2 the x-size of the sprite so the edge will always be inside the game space
		padding = this.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;
		
		ymin = bottommost.y - padding;
		ymax = uppermost.y + padding;
	}

	void Update ()
	{
		//transform.position += Vector3.up * speed * Time.deltaTime;
		this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed + Time.deltaTime, 0);

		if (transform.position.y > ymax || transform.position.y < ymin)
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
