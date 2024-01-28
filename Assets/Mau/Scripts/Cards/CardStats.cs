using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardStats : MonoBehaviour
{
    [SerializeField] SpritesContainer _spritesContainer;
    [SerializeField] MemeCard _memeCard;
    [SerializeField] Sprite _stpSprite;
    [SerializeField] Sprite _fnySprite;
    [SerializeField] Sprite _crngSprite;
    
    public void GenerateInformation()
    {
        int type = (int)Mathf.Round(Random.Range(0, 3));
        int stat = (int)Mathf.Round(Random.Range(1, 5));
        if (type == 0)
        {
            _memeCard.SendStatsAndSprite(_crngSprite, stat);
            return;
        }
        if (type == 1)
        {
            _memeCard.SendStatsAndSprite(_fnySprite, stat);
            return;
        }
        if (type == 2)
        {
            _memeCard.SendStatsAndSprite(_stpSprite, stat);
            return;
        }
    }

    public int GenerateStats()
    {
        int stat = (int)Mathf.Round(Random.Range(1, 5));
        return stat;
    }

    public MemeCardScriptable GetSpriteAndName()
    {
        return _spritesContainer.SendRandomMeme();
    }
}
