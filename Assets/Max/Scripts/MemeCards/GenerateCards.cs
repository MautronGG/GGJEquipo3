using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCards : MonoBehaviour
{
  [SerializeField] SpritesContainer _spritesContainer;
  [SerializeField] GameObject _memeCardPrefab;
  GameObject memeCard;
  float timer;
  bool startTimer = false;

  public GameObject SendMemeCard(Transform transform)
  {
    memeCard = Instantiate(_memeCardPrefab, transform);
    startTimer = true;
    return memeCard;
  }
  private void Update()
  {
    if (startTimer)
    {
      timer += Time.deltaTime;
      if (timer >= 2.5f)
      {
        memeCard.SetActive(false);
        startTimer = false;
        timer = 0f;
      }
    }
  }
}
