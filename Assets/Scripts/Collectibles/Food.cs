﻿using System.Collections.Generic;
using UnityEngine;
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
	}

	private void OnTriggerEnter(Collider other)
	{
		foodCounter++;
		int ratsBefore = rats.Count;
		if (other.gameObject.layer == 8)
		{

			for (int i = 0; i < nbrOfRatToAdd; i++)
			{
				Rat currentRat = Instantiate(ratPrefab, transform.position, Quaternion.identity, ratHolder);
				levelSetter.Rats.Add(currentRat);
				if (i == nbrOfRatToAdd - 1 && foodCounter % 5 == 0 && foodCounter != 0)
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
			if (FindObjectOfType<MusicPlayer>() != null)
			{
				MusicPlayer music = FindObjectOfType<MusicPlayer>();
				music.changeMusicParameter(ratsBefore, rats.Count);
			}

			//Debug.Log(foodCounter + "after la bouffe le kfc");
			Destroy(gameObject);
		}
	}
}
