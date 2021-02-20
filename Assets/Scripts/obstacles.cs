using UnityEngine;

public class obstacles : MonoBehaviour
{
	[SerializeField] private int RatsToKill = 10;

	private LevelSetter levelSetter;

	protected void Start()
	{
		levelSetter = FindObjectOfType<LevelSetter>();
	}

	public void DestroyRats()
	{
		for (int i = 0; i < RatsToKill; i++)
		{
			Rat ratToKill = levelSetter.Rats.Random();
			levelSetter.Rats.Remove(ratToKill);
			Destroy(ratToKill.gameObject);
			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			int ratsBefore = levelSetter.Rats.Count;
			DestroyRats();
			levelSetter.removeEmitter();
			if(FindObjectOfType<MusicPlayer>() != null)
            {
				MusicPlayer music = FindObjectOfType<MusicPlayer>();
				music.changeMusicParameter(ratsBefore, levelSetter.Rats.Count);
			}

			Destroy(gameObject);
		}
	}
}
