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
	public void changeMusicParameter()
	{
		if (levelSetter != null)
		{
			UnityEngine.Debug.Log(levelSetter.Rats.Count);
			if (levelSetter.Rats.Count % 20 == 0 && parameterValue < 1 && levelSetter.Rats.Count > 20)
			{
				UnityEngine.Debug.Log("et HOP");
				parameterValue += 0.1f;
				GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("SIZE", parameterValue);
			}
		}

	}
}
