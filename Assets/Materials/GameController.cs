using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private bool started = false;

	private static GameController instance;

	public static GameController Instance()
	{
		if(instance == false)
		{
			instance = GameObject.FindObjectOfType<GameController>();
		}
		return instance;
	}

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

	public void Win()
	{
		Time.timeScale = 0;

		if(Application.loadedLevel < Application.levelCount - 1)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			GameObject gameArea = GameObject.Find("Game Area");
			GameObject gameOverPanel = Instantiate(Resources.Load("Game Over") as GameObject);
			gameOverPanel.transform.SetParent(gameArea.transform, false);
		}
		
	}
}
