using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed = 15f;

	float xmin;
	float xmax;
	float padding;

	void Start()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		// Pad the value by 1/2 the x-size of the sprite so the edge will always be inside the game space
		padding = this.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f;

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}

	void Update () {
	
		Vector3 playerPos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);

		if (Input.GetKey(KeyCode.LeftArrow))
			transform.position += Vector3.left * speed * Time.deltaTime;

		if (Input.GetKey(KeyCode.RightArrow))
			transform.position += Vector3.right * speed * Time.deltaTime;

		// Restrict player to the game space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);

	}
}
