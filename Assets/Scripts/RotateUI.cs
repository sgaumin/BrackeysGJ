using UnityEngine;

public class RotateUI : MonoBehaviour
{
	private void Update()
	{
		transform.rotation = Camera.main.transform.rotation;
	}
}
