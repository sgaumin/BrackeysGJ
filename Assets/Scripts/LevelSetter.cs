using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
  [Header("Level Parameters")]
  [SerializeField] private int ratCountAtStart = 6;

  [Header("References")]
  [SerializeField] private Rat ratPrefab;
  [SerializeField] private Transform ratHolder;

  protected void Start()
  {
    for (int i = 0; i < ratCountAtStart; i++)
    {
      Instantiate(ratPrefab, ratHolder);
    }
  }
}
