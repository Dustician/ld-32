using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

	private bool firstStop = false;
	private bool secondStop = false;

	private bool stopped = false;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1") && stopped)
		{
			stopped = false;
			Time.timeScale = 1;
		}

		if(transform.localPosition.y >= 93 && !firstStop)
		{
			stopped = true;
			Time.timeScale = 0;
			firstStop = true;
			GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = "The ball's trajectory can be changed by activating magnets\n\nPress \"1\" to activate the magnet now";
		}

		if (firstStop && !secondStop && transform.localPosition.x >= -180)
		{
			stopped = true;
			Time.timeScale = 0;
			secondStop = true;
			GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = "Deactivating the magnet will cause the ball to continue with it's present velocity\n\nPress \"1\" to deactivate the magnet now";
		}
	}
}
