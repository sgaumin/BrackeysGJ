using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Rat : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private NavMeshAgent agent;
	public List<Rat> rats { get; set; } = new List<Rat>();
	private PlayerController player;
	private LevelSetter levelSetter;


	protected void Start()
	{
		player = FindObjectOfType<PlayerController>();
		levelSetter = FindObjectOfType<LevelSetter>();
	}

	private void Update()
	{
		agent.SetDestination(player.Destination);
	}

	public void Kill()
	{
		levelSetter.Rats.Remove(this);
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		levelSetter.playerState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
}
