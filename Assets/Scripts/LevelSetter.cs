using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
	[Header("Level Parameters")]
	[SerializeField] private int ratCountAtStart = 6;
	[SerializeField] private float verticalTriggerFloor = 1f;

	[Header("Sound")]
	public FMOD.Studio.EventInstance playerState;
	[FMODUnity.EventRef] public string PlayerStateEvent = "";

	[Header("References")]
	[SerializeField] private Transform ratPositionPoint;
	[SerializeField] private Rat ratPrefab;
	[SerializeField] private Transform ratHolder;
	[SerializeField] private GameObject secondFloor;

	private int nbrEventInstances = 0;

	public List<Rat> Rats { get; set; } = new List<Rat>();

	protected void Start()
	{
		for (int i = 0; i < ratCountAtStart; i++)
		{
			Rat currentRat = Instantiate(ratPrefab, ratHolder);
			Rats.Add(currentRat);
			if (i == ratCountAtStart - 1)
			{
				//UnityEngine.Debug.Log("On rentre dans le if");
				addEmitter(currentRat.transform);

				//Instantiate(moveEmitter, currentRat.transform);
			}
		}
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
			//UnityEngine.Debug.Log("nbr instances " + nbrEventInstances);
		}
		else
		{
			//UnityEngine.Debug.Log("nope");
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
