using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClotheStats : MonoBehaviour
{
  public string clotheName;
  public string statName;
  public Image statSprite;
  public int cringe;
  public int funny;
  public int stupidity;

  public TextMeshPro _statNumber;
  public TextMeshPro _statName;
  public TextMeshPro _clotheName;
  private void Awake()
  {
    cringe = (int)Mathf.Round(Random.Range(-1, 4));
    funny = (int)Mathf.Round(Random.Range(-1, 4));
    stupidity = (int)Mathf.Round(Random.Range(-1, 4));
  }
  public void ChangeUIText(int stat, string name, string cardName)
  {
    _statNumber.text = "+ " + stat.ToString();
    _statName.text = name;
    _clotheName.text = cardName;
  }
}
