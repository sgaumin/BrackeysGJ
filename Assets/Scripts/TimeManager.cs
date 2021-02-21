using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	[SerializeField]
	float timeInSeconds;
	[SerializeField]
	Text timer;

	private Game game;

	void Start()
	{
		game = FindObjectOfType<Game>();
	}

	void Update()
	{
		launchTimer();
	}

	public void launchTimer()
	{
		timeInSeconds -= Time.deltaTime % 60;
		float timeLeft = Mathf.RoundToInt(timeInSeconds);

		if (timeInSeconds <= 0)
		{
			game.LoadSceneByName("Lose");

		}
		else
		{
			timer.text = timeLeft + "";
			//Debug.Log(timeInSeconds);
		}
	}
}
