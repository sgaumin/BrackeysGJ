using UnityEngine;
using System.Collections.Generic;
public class Food : MonoBehaviour
{
	[SerializeField] private int nbrOfRatToAdd = 10;
	[SerializeField] private Rat ratPrefab;

	public List<Rat> rats = new List<Rat>();
	private LevelSetter levelSetter;
	private Transform ratHolder;
	private static int foodCounter;

	void Start()
	{
		levelSetter = FindObjectOfType<LevelSetter>();
		ratHolder = GameObject.Find("RatHolder").transform;
		rats = FindObjectOfType<LevelSetter>().Rats;
	
		//MoveSound = GameObject.FindGameObjectsWithTag("MoveEmitter");
		//Debug.Log("ratholder" + ratHolder);
		//Debug.Log("ratPrefab" + ratPrefab);
	}

	private void OnTriggerEnter(Collider other)
	{
		foodCounter++;
		Debug.Log("nombre de rats before" + rats.Count);
		if (other.gameObject.layer == 8)
		{

			for (int i = 0; i < nbrOfRatToAdd; i++)
			{
				Rat currentRat = Instantiate(ratPrefab, transform.position, Quaternion.identity, ratHolder);
				levelSetter.Rats.Add(currentRat);
				if(i == nbrOfRatToAdd-1 && foodCounter % 5 == 0 && foodCounter != 0)
                {
					Debug.Log("each 5 " + foodCounter);
					//Debug.Log("nombre de rats after" +FindObjectOfType<LevelSetter>().Rats.Count);
					FindObjectOfType<LevelSetter>().addEmitter(currentRat.transform);
                }
                else
                {
					//Debug.Log("nombre d'isntances " + nbrEventInstances);
                }
			}
			MusicPlayer music = FindObjectOfType<MusicPlayer>();
			music.changeMusicParameter();
			//Debug.Log(foodCounter + "after la bouffe le kfc");
			Destroy(gameObject);
		}
	}
}
