using DG.Tweening;
using TMPro;
using Tools.Utils;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField, IntRangeSlider(-180, 180)] private IntRange rotationAngle = new IntRange(110, 130);
	[SerializeField] private float ratCountToOpen = 20;
	[SerializeField] private bool isFinal;

	[Header("Sounds")]
	[FMODUnity.EventRef] public string doorSound = "";
	public FMOD.Studio.EventInstance doorState;
	[FMODUnity.EventRef] public string doorClosed = "";
	public FMOD.Studio.EventInstance doorClosedState;

	[Header("Animations")]
	[SerializeField] private float openingDoorDuration = 0.5f;
	[SerializeField] private Ease openingDoorEase = Ease.OutBounce;

	[Header("References")]
	[SerializeField] private TextMeshProUGUI description;

	private bool hasBeenUnlocked;
	private LevelSetter levelSetter;
	private int displayCount;
	private Game game;

	void Start()
	{
		game = FindObjectOfType<Game>();
		levelSetter = FindObjectOfType<LevelSetter>();
	}

	private void Update()
	{
		displayCount = levelSetter.Rats.IsEmpty() ? 0 : levelSetter.Rats.Count;
		description.text = $"{displayCount}/{ratCountToOpen}";
		description.color = displayCount >= ratCountToOpen ? Color.green : Color.red;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rat")
		{
			if (levelSetter.Rats.Count >= ratCountToOpen && !hasBeenUnlocked)
			{
				Rotate();

				if (isFinal)
				{
					game.LoadSceneByName("Win");
				}
			}
			else
			{
				FMODUnity.RuntimeManager.PlayOneShot(doorClosed, transform.position);
			}
		}
	}

	private void Rotate()
	{
		description.gameObject.SetActive(false);
		FMODUnity.RuntimeManager.PlayOneShot(doorSound, transform.position);
		hasBeenUnlocked = true;

		Vector3 targetRotation = transform.rotation.eulerAngles + Vector3.zero.withY(rotationAngle.RandomValue);
		transform.DORotate(targetRotation, openingDoorDuration).SetEase(openingDoorEase);
	}
}
