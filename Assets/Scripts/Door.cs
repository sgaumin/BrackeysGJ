using System.Collections;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private float rotationAngle;
	[SerializeField] private float ratCountToOpen = 20;

	[Header("Sounds")]
	[FMODUnity.EventRef] public string doorSound = "";
	public FMOD.Studio.EventInstance doorState;
	[FMODUnity.EventRef] public string doorClosed = "";
	public FMOD.Studio.EventInstance doorClosedState;

	[Header("References")]
	[SerializeField] private TextMeshProUGUI description;

	private Transform parent;
	private bool isRotating;
	private int ratsCount;
	private LevelSetter levelSetter;
	private int displayCount;

	void Start()
	{
		levelSetter = FindObjectOfType<LevelSetter>();

		parent = gameObject.transform.parent;
		isRotating = false;
	}

	private void Update()
	{
		displayCount = levelSetter.Rats.IsEmpty() ? 0 : levelSetter.Rats.Count;
		description.text = $"{displayCount}/{ratCountToOpen}";
		description.color = displayCount >= ratCountToOpen ? Color.green : Color.red;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Rat")
		{
			ratsCount = FindObjectOfType<LevelSetter>().Rats.Count;
			if (ratsCount >= ratCountToOpen)
			{
				Debug.Log("collider");

				Quaternion rotation = Quaternion.identity;
				//rotation.eulerAngles = new Vector3(0, 90, 0);
				//parent.transform.rotation = rotation;
				if (isRotating == false)
				{
					StartCoroutine(Rotate(0.2f, rotationAngle, rotation));
				}

				//parent.position = new Vector3(parent.position.x + 5, parent.position.y, parent.position.z);
			}
			else
			{
				FMODUnity.RuntimeManager.PlayOneShot(doorClosed, transform.position);
			}

		}

	}
	IEnumerator Rotate(float duration, float rotationAngle, Quaternion objectToRotate)
	{
		description.gameObject.SetActive(false);
		float startRotation = transform.eulerAngles.y;
		float endRotation = startRotation + rotationAngle;

		float t = 0.0f;
		//Time.timeScale = 0.2f;
		//Debug.Log("on est dans le cas ou r > 0" + parent.transform.rotation.y);
		FMODUnity.RuntimeManager.PlayOneShot(doorSound, transform.position);
		while (t < duration)
		{
			isRotating = true;
			t += Time.deltaTime;
			if (rotationAngle < 0)
			{
				float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAngle;
				yRotation += transform.eulerAngles.y;
				objectToRotate.eulerAngles = new Vector3(parent.eulerAngles.x, yRotation,
				parent.eulerAngles.z);
				parent.transform.rotation = objectToRotate;
				//parent.transform.Rotate(Vector3.down, 0.5f);

			}
			/*                if(rotationAngle > 0)
							{
							float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % rotationAngle;
							yRotation -= transform.eulerAngles.y;
							objectToRotate.eulerAngles = new Vector3(parent.eulerAngles.x, yRotation,
							parent.eulerAngles.z);
							parent.transform.rotation = objectToRotate;
							//parent.transform.Rotate(Vector3.up, 0.5f);

							}*/


			//Time.timeScale = 1.0f;
			yield return null;
		}
		if (t == duration)
		{
			isRotating = false;
		}

		//yield return new WaitForSeconds(0.01f);
	}
}
