using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPillController : MonoBehaviour {

	public Vector3 movement_vector;
	private float x_direction;//0 is stationary, 1 is positive, -1 is negative
	private float y_direction;//0 is stationary, 1 is up, -1 is down
	private float z_direction;//0 is stationary, 1 is positive, -1 is negative
	public float speed;

	private bool GoingOut;
	private Vector3 start_pos;
	private Vector3 movement_direction;


	// Use this for initialization
	void Start () {

		GoingOut = true;
		start_pos = transform.position;

		if (movement_vector.x > 0) {
			x_direction = 1;
		}else if (movement_vector.x < 0)
		{
			x_direction=-1;
		}
		if (movement_vector.y > 0) {
			y_direction = 1;
		} else if (movement_vector.y < 0) {
			y_direction = -1;
		}
		if (movement_vector.z > 0) {
			z_direction = 1;
		} else if (movement_vector.z < 0) {
			z_direction = -1;
		}



		movement_direction = new Vector3(x_direction, y_direction, z_direction);
		//movement_forward = transform.InverseTransformDirection (movement_forward);
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (-15, -30, -45) * Time.deltaTime); //Time.deltaTime used to make it smooth and framerate indep.
		
	}

	void FixedUpdate () {

		if (Vector3.Distance(transform.position, start_pos + movement_vector) > .001f  && GoingOut == true) {

			transform.Translate(movement_direction * speed * Time.deltaTime, Space.World);

		}
		else if (Vector3.Distance(transform.position, start_pos + movement_vector) <= .001f && GoingOut == true)
		{
			GoingOut = false;
		}

		if (Vector3.Distance(transform.position, start_pos) > .001f && GoingOut == false) {

			transform.Translate(movement_direction * -1 * speed * Time.deltaTime, Space.World);
		}
		else if (Vector3.Distance(transform.position, start_pos) <= .001f && GoingOut == false)
		{
			GoingOut = true;
		}



	}
}
