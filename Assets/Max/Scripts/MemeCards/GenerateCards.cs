using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCards : MonoBehaviour
{
    [SerializeField] SpritesContainer _spritesContainer;
    [SerializeField] GameObject _memeCardPrefab;

    public GameObject SendMemeCard()
    {
        GameObject memeCard = Instantiate(_memeCardPrefab);
        memeCard.GetComponent<MemeCard>().SpriteAndName(_spritesContainer.SendRandomMeme());
        return memeCard;
    }
}