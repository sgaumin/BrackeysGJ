using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMOD;

[RequireComponent(typeof(NavMeshAgent))]
public class Rat : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private NavMeshAgent agent;
	public List<Rat> rats { get; set; } = new List<Rat>();
	private PlayerController player;


	protected void Start()
	{
		player = FindObjectOfType<PlayerController>();
		//rats = FindObjectOfType<LevelSetter>().Rats;
		
		

	}

	private void Update()
	{
		//UnityEngine.Debug.Log("nombre de rats " + rats.Count);
		agent.SetDestination(player.Destination);

	}
}
