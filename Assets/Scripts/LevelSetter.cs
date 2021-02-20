using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
  [Header("Level Parameters")]
  [SerializeField] private int ratCountAtStart = 6;

  [Header("References")]
  [SerializeField] private Transform ratPositionPoint;
  [SerializeField] private Rat ratPrefab;
  [SerializeField] private Transform ratHolder;

  List<Rat> rats = new List<Rat>();

  protected void Start()
  {
    for (int i = 0; i < ratCountAtStart; i++)
    {
      Rat currentRat = Instantiate(ratPrefab, ratHolder);
      rats.Add(currentRat);
    }
  }

  private void Update()
  {
    if (!rats.IsEmpty())
    {
      rats.ForEach(x => ratPositionPoint.position += x.transform.position);
      ratPositionPoint.position /= rats.Count; 
    }
  }
}
