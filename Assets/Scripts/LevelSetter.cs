using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class LevelSetter : MonoBehaviour
{
	[Header("Level Parameters")]
	[SerializeField] private int ratCountAtStart = 6;
	[SerializeField] private float verticalTriggerFloor = 1f;

	[Header("Sound")]
	public FMOD.Studio.EventInstance playerState;
	[FMODUnity.EventRef] public string PlayerStateEvent = "";

	[Header("Debug")]
	[SerializeField] private float timeObstaclesDeactivation = 0.7f;
	[SerializeField] private float distanceRatSpawnBugCheck = 4f;

	[Header("References")]
	[SerializeField] private Transform ratPositionPoint;
	[SerializeField] private Rat ratPrefab;
	[SerializeField] private Transform ratHolder;
	[SerializeField] private Transform startSpawn;
	[SerializeField] private GameObject secondFloor;

	private int nbrEventInstances = 0;
	private List<NavMeshObstacle> navMeshObstacles = new List<NavMeshObstacle>();

	public List<Rat> Rats { get; set; } = new List<Rat>();
	public Vector3 StartSpawn => startSpawn.position;

	protected void Start()
	{
		navMeshObstacles = FindObjectsOfType<NavMeshObstacle>().ToList();
		navMeshObstacles.ForEach(x => x.enabled = false);

		StartCoroutine(SpawnRats());
		StartCoroutine(BugCorrection());
	}

	private IEnumerator SpawnRats()
	{
		for (int i = 0; i < ratCountAtStart; i++)
		{
			Rat currentRat = Instantiate(ratPrefab, ratHolder);
			Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
			currentRat.transform.position = startSpawn.position + offset;
			Rats.Add(currentRat);

			if (i == ratCountAtStart - 1)
			{
				addEmitter(currentRat.transform);
			}

			yield return null;
		}
	}

	private IEnumerator BugCorrection()
	{
		yield return new WaitForSeconds(timeObstaclesDeactivation);
		navMeshObstacles.ForEach(x => x.enabled = true);

		List<Rat> ratToKill = new List<Rat>();
		foreach (Rat rat in Rats)
		{
			float distance = Vector3.Distance(rat.transform.position, startSpawn.position);
			if (distance > distanceRatSpawnBugCheck)
			{
				ratToKill.Add(rat);
			}
		}

		ratToKill.ForEach(x => x.Kill());
	}

	private void Update()
	{
		if (!Rats.IsEmpty())
		{
			foreach (Rat rat in Rats)
			{
				if (rat == null)
					continue;

				ratPositionPoint.position += rat.transform.position;
			}

			ratPositionPoint.position /= Rats.Count;
		}

		secondFloor.SetActive(ratPositionPoint.position.y >= verticalTriggerFloor);
	}
	public void addEmitter(Transform parentRat)
	{
		if (nbrEventInstances < 5)
		{
			playerState = FMODUnity.RuntimeManager.CreateInstance(PlayerStateEvent);
			playerState.start();
			FMODUnity.RuntimeManager.AttachInstanceToGameObject(playerState, parentRat, GetComponent<Rigidbody>());
			nbrEventInstances++;
		}
	}

	public void removeEmitter()
	{
		if (nbrEventInstances > 1)
		{
			playerState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			nbrEventInstances--;
		}
	}
}
