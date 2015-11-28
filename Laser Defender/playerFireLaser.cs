using UnityEngine;
using System.Collections;

public class playerFireLaser : MonoBehaviour 
{

	public GameObject playerLaser;

	public int maxLasers = 3;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;


	void Update () 
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

			GameObject[] lasers = GameObject.FindGameObjectsWithTag("laserfire");

			int count = 0;
			foreach (GameObject lasera in lasers)
			{
				count++;
			}

			//if (GameObject.Find ("laserBlue01(Clone)") == null)
			if (count < maxLasers)
			{
				GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
				//laser.transform.parent = child;
			}
		}
	}
}
