using UnityEngine;

public class Food : MonoBehaviour
{
	[SerializeField] private int nbrOfRatToAdd = 10;
	[SerializeField] private Rat ratPrefab;

	private LevelSetter levelSetter;
	private Transform ratHolder;

	void Start()
	{
		levelSetter = FindObjectOfType<LevelSetter>();
		ratHolder = GameObject.Find("RatHolder").transform;

		Debug.Log("ratholder" + ratHolder);
		Debug.Log("ratPrefab" + ratPrefab);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			for (int i = 0; i < nbrOfRatToAdd; i++)
			{
				Rat currentRat = Instantiate(ratPrefab, transform.position, Quaternion.identity, ratHolder);
				levelSetter.Rats.Add(currentRat);
			}

			Destroy(gameObject);
		}
	}
}
