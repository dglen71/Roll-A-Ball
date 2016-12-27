using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour {

	public float move_distance;
	public float x_direction;//0 is stationary, 1 is positive, -1 is negative
	public float y_direction;//0 is stationary, 1 is up, -1 is down
	public float z_direction;//0 is stationary, 1 is positive, -1 is negative
	public float speed;

	private bool GoingOut;
	private float start_pos;

	// Use this for initialization
	void Start () {
		
		GoingOut = true;
		start_pos = transform.position.magnitude;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		Vector3 movement_forward = new Vector3(x_direction, y_direction, z_direction);

		if (transform.position.magnitude < (start_pos + move_distance) && GoingOut == true) {

			transform.Translate(movement_forward * speed * Time.deltaTime);

		}
		else if (transform.position.magnitude >= (start_pos + move_distance) && GoingOut == true)
			{
			GoingOut = false;
			}

		if (transform.position.magnitude > (start_pos) && GoingOut == false) {

			transform.Translate(movement_forward * -1 * speed * Time.deltaTime);
		}
		else if (transform.position.magnitude <= (start_pos) && GoingOut == false)
		{
			GoingOut = true;
		}


		
	}
}
