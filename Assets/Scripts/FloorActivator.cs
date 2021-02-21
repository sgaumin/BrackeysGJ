using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FloorActivator : MonoBehaviour
{
	[SerializeField, Range(0f, 1f)] private float ratPercentageForSwitch = 0.6f;

	[Header("References")]
	[SerializeField] private GameObject floorToActivate;

	private int ratCount = 0;
	private LevelSetter levelSetter;
	private FloorActivator[] floorActivators;

	protected void Start()
	{
		levelSetter = FindObjectOfType<LevelSetter>();
		floorActivators = FindObjectsOfType<FloorActivator>();

		ResetStatus();
	}

	public void ResetStatus()
	{
		ratCount = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			if (++ratCount >= levelSetter.Rats.Count * ratPercentageForSwitch)
			{
				floorToActivate.SetActive(!floorToActivate.activeSelf);
				floorActivators.ForEach(x => x.ResetStatus());
			}
		}
	}
}
