using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemeCard : MonoBehaviour
{
    [SerializeField] CardStats _cardStats;
    [SerializeField] TextMeshProUGUI _nameTxt;
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _statTxt;
    [SerializeField] Image _typeSprite;
    private int _powerStat;

    private void OnEnable()
    {
        _cardStats.GenerateInformation();
    }

    public void SendStatsAndSprite(Sprite sprite, int stat)
    {
        _powerStat = stat;
        _statTxt.text = _powerStat.ToString();
        _typeSprite.sprite = sprite;
    }

    public void SpriteAndName()
    {
        MemeCardScriptable memeCard = _cardStats.GetSpriteAndName();
        _image.sprite = memeCard.sprite;
        _nameTxt.text = memeCard.memeName;
    }
}
