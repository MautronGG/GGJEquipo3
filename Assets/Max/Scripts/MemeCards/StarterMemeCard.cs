using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarterMemeCard : MonoBehaviour
{
    [SerializeField] CardStats _cardStats;
    [SerializeField] TextMeshProUGUI _nameTxt;
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _stpTxt;
    [SerializeField] TextMeshProUGUI _fnyTxt;
    [SerializeField] TextMeshProUGUI _crngTxt;
    private int _stpStat;
    private int _fnyStat;
    private int _crngStat;

    private void OnEnable()
    {
        EstablishStats();
        GetMemeSprite();
    }

    public void EstablishStats()
    {
        _stpStat = _cardStats.GenerateStats();
        _stpTxt.text = _stpStat.ToString();
        _fnyStat = _cardStats.GenerateStats();
        _fnyTxt.text = _fnyStat.ToString();
        _crngStat = _cardStats.GenerateStats();
        _crngTxt.text = _crngStat.ToString();
    }

    private void GetMemeSprite()
    {
        MemeCardScriptable meme = _cardStats.GetSpriteAndName();
        _nameTxt.text = meme.memeName;
        _image.sprite = meme.sprite;
    }
}
