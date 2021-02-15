using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private LayerMask movementLayer;
	[SerializeField] private string inputName;

	public Vector3 Destination { get; private set; }

	private RaycastHit hit;
	private Ray ray;

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
