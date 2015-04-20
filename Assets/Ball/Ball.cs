using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float xVel = 0;
	public float yVel = 3;
	public float velMag = 3;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Vector2 normVel = GetComponent<Rigidbody2D>().velocity.normalized;
		//GetComponent<Rigidbody2D>().velocity = velMag * normVel;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Barrier"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if(other.gameObject.CompareTag("Target"))
		{
			GameController.Instance().Win();
		}
	}
}
