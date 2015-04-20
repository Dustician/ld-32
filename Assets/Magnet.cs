using UnityEngine;
using System.Collections.Generic;

public class Magnet : MonoBehaviour {

	public float force = 5.0f;
	public static float range = 1000;
	public bool powered = false;
	public string powerKey = "1";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(powerKey) && GameController.Instance().started)
		{
			TogglePower();
		}
	}

	void FixedUpdate()
	{
		if (powered)
		{
			ApplyForce();
		}
	}

	void ApplyForce()
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range);
		List<Rigidbody2D> rbs = new List<Rigidbody2D>();

		foreach (Collider2D c in cols)
		{
			Rigidbody2D rb = c.attachedRigidbody;
			if (rb && rb != GetComponent<Rigidbody2D>() && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector2 offset = transform.position - c.transform.position;
				rb.AddForce(force * offset / offset.sqrMagnitude);
			}
		}
	}

	void TogglePower()
	{
		AudioClip clip;
		if(!powered)
		{
			clip = Resources.Load("power_on") as AudioClip;
		}
		else
		{
			clip = Resources.Load("power_off") as AudioClip;
		}
		GameController.Instance().GetComponentInChildren<AudioSource>().PlayOneShot(clip, .2f);
		powered = !powered;
	}
}
