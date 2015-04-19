using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool started = false;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && !started)
		{
			Time.timeScale = 1;
		}
	}
}
