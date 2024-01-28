using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCards : MonoBehaviour
{
    [SerializeField] SpritesContainer _spritesContainer;
    [SerializeField] GameObject _memeCardPrefab;

    public GameObject SendMemeCard(Transform transform)
    {
        GameObject memeCard = Instantiate(_memeCardPrefab, transform);
        return memeCard;
    }
}
