using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Rat : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private NavMeshAgent agent;

	private PlayerController player;

	protected void Start()
	{
		player = FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		agent.SetDestination(player.Destination);
	}
}
