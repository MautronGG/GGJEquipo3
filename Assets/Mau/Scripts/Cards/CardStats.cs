using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardStats : MonoBehaviour
{
  public string cardName;
  public string statName;
  //public Image sprite;
  public int cringe;
  public int funny;
  public int stupidity;

  public TextMeshPro _statNumber;
  public TextMeshPro _statName;
  public TextMeshPro _cardName;
  private void Awake()
  {
    var stat = (int)Mathf.Round(Random.Range(0, 3));
    if (stat == 0)
    {
      SetStat(cringe);
      return;
    }
    if (stat == 1)
    {
      SetStat(funny);
      return;
    }
    if (stat == 2)
    {
      SetStat(stupidity);
      return;
    }
    //cringe = (int)Mathf.Round(Random.Range(0, 2));
    //funny = (int)Mathf.Round(Random.Range(0, 2));
    //stupidity = (int)Mathf.Round(Random.Range(0, 2));
  }
  public void SetStat(int stat)
  {
    stat = (int)Mathf.Round(Random.Range(1, 5));
  }
  public void ChangeUIText(int stat, string name, string cardName)
  {
    _statNumber.text = stat.ToString();
    _statName.text = name;
    _cardName.text = cardName;
  }
}
