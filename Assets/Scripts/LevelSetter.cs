using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
	[Header("Level Parameters")]
	[SerializeField] private int ratCountAtStart = 6;

	[Header("References")]
	[SerializeField] private Transform ratPositionPoint;
	[SerializeField] private Rat ratPrefab;
	[SerializeField] private Transform ratHolder;

	public List<Rat> Rats { get; set; } = new List<Rat>();

	protected void Start()
	{
		for (int i = 0; i < ratCountAtStart; i++)
		{
			Rat currentRat = Instantiate(ratPrefab, ratHolder);
			Rats.Add(currentRat);
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
	}
}
