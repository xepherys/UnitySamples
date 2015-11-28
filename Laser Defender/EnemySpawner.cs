using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	private bool movingRight = false;
	
	public float speed = 10f;

	public float width = 10f;
	public float height = 5f;

	private float xmin;
	private float xmax;
	private float padding;

	public int backAndForthToMove = 3;
	private int backAndForth = 0;



	// Use this for initialization
	void Start () {

		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		xmax = rightmost.x;
		xmin = leftmost.x;

		foreach (Transform child in transform)
		{
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}

	void Update () {
		
		if (movingRight)
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		if (!movingRight)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + 0.5f*width;
		float leftEdgeOfFormation = transform.position.x - 0.5f*width;

		if (leftEdgeOfFormation < xmin)
		{
			movingRight = false;
			backAndForth++;
		}

		else if (rightEdgeOfFormation > xmax)
		{
			movingRight = true;
			backAndForth++;
		}

		if (backAndForth == backAndForthToMove)
		{
			backAndForth = 0;
			transform.position += Vector3.down * speed / 20;
		}
	}
}
