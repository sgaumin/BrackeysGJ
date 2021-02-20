using UnityEngine;
using FMOD;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Instance { get; private set; }
	private LevelSetter levelSetter;
	float parameterValue = 0;
	protected void Awake()
	{


		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (FindObjectOfType<LevelSetter>() != null)
		{
			levelSetter = FindObjectOfType<LevelSetter>();
		}
	}
	private void Update()
    {
		
		SceneManager.sceneLoaded += OnSceneLoaded;




	}
	public void changeMusicParameter(int countBefore, int countAfter)
	{
		UnityEngine.Debug.Log(countBefore + " " + countAfter);
		if (levelSetter != null)
		{
			//UnityEngine.Debug.Log(levelSetter.Rats.Count);
			if (levelSetter.Rats.Count % 20 == 0)
			{
				if(parameterValue < 1 && levelSetter.Rats.Count > 20 && countBefore < countAfter)
                {
					parameterValue += 0.1f;
					GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("SIZE", parameterValue);
				}
				if (countBefore > countAfter)
				{
					UnityEngine.Debug.Log("et hop on diminue la musique");
					parameterValue -= 0.1f;
					GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("SIZE", parameterValue);
				}
				//UnityEngine.Debug.Log("et HOP");

			}

		}
		

	}
}
