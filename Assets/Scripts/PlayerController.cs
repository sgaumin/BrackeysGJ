using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask movementLayer;
	[SerializeField] private string inputName;

	[Header("References")]
	[SerializeField] private LevelSetter levelSetter;

	private RaycastHit hit;
	private Ray ray;

	public Vector3 Destination { get; private set; }

	protected void Start()
	{
		Destination = levelSetter.StartSpawn;
	}

	private void Update()
	{
		if (string.IsNullOrEmpty(inputName))
		{
			RetreiveDestination();
		}
		else if (Input.GetButton(inputName))
		{
			RetreiveDestination();
		}
	}

	private void RetreiveDestination()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, movementLayer, QueryTriggerInteraction.Ignore))
		{
			Destination = hit.point;
		}
	}
}
