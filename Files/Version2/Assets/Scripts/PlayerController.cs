using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;
	public float time_left;
	private float time_init;

	private Rigidbody rb;
	private int count;
	private bool SpedUp;
	private float startTime;
	private float gameTime;
	private bool KeepTime;

	void Start() //Occurs on the first frame of the game
	{
		rb = GetComponent <Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		SpedUp = false;
		time_init = time_left;
		startTime = Time.time;
		gameTime = 0;
		KeepTime = true;

	}

	void Update() // Occurs before rendering a frame
	{
		if (KeepTime == true) {

			gameTime = Time.time - startTime;
			float min =  gameTime / 60f;
			float sec = gameTime % 60f;
			float milisec = gameTime * 100f % 100f;
			timeText.text =  Mathf.FloorToInt(min) + ":" + Mathf.FloorToInt(sec)  + ":" + Mathf.FloorToInt(milisec);

		}

		/*
		if (transform.position.y > 0.5f) {

			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		}
		*/



	}

	void FixedUpdate() //Occurs before any physics calculations
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		if (SpedUp == false) {
			
			rb.AddForce (movement * speed);

		} else if (SpedUp == true) {

			rb.AddForce (movement * speed * 2);
		}


		if (SpedUp == true && time_left > 0) {

			time_left -= Time.deltaTime;

		} else if (SpedUp = true && time_left <= 0) {

			SpedUp = false;
			time_left = time_init;

		}

		if (transform.position.y <= -10.0f) {

			transform.position = Vector3.zero;
		}

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Stop Pill")) 
		{
			other.gameObject.SetActive (false);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}

		if (other.gameObject.CompareTag ("Speed Up")) 
		{
			SpedUp = true;
		}

		if (other.gameObject.CompareTag ("Warp")) {

			int warp_number = Random.Range (1, 5);
			switch (warp_number) {

			case 1:
				transform.position = new Vector3 (-12.0f, 0.5f, 17.0f);
				break;
			case 2:
				transform.position = new Vector3  (12.0f, 0.5f, 17.0f);
				break;
			case 3:
				transform.position = new Vector3  (12.0f, 0.5f, -17.0f);
				break;
			case 4:
				transform.position = new Vector3  (-12.0f, 0.5f, -17.0f);
				break;

			}
		}


	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
			KeepTime = false;
		}
	}
}


