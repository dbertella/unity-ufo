using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text niceTime;

	private DateTime startTime;
	private int count;
	private Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		startTime = DateTime.Now;
		winText.text = "";
		niceTime.text = "";
		setCountText ();
	}
	
	void FixedUpdate () {
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		Timer_Tick ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive(false);
			count++;
			setCountText ();
		}
	}

	void setCountText() {
		countText.text = string.Format("Count: {0}", count.ToString ());

		if (count >= 12) {
			winText.text = string.Format("You win: {0}", niceTime.text);
		}
	}

	private void Timer_Tick() {
		if (count < 12) {
			TimeSpan timeElapsed = DateTime.Now - startTime;
			niceTime.text = timeElapsed.TotalSeconds.ToString ("0.000");
		}
	}
}
