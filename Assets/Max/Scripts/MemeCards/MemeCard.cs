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
    [SerializeField] TextMeshProUGUI _stpStatTxt;
    [SerializeField] TextMeshProUGUI _fnyStatTxt;
    [SerializeField] TextMeshProUGUI _crngStatTxt;
    private int _stpStat;
    private int _fnyStat;
    private int _crngStat;

    private void OnEnable()
    {
        _cardStats.GenerateInformation();
    }

    public void SendStats(string statType, int stat)
    {
        if (statType == "stpStat")
        {
            _stpStat = stat;
            Debug.Log(statType + ": " + stat);
        }
        else if (statType == "fnyStat")
        {
            _fnyStat = stat;
            Debug.Log(statType + ": " + stat);
        }
        else if (statType == "crngStat")
        {
            _crngStat = stat;
            Debug.Log(statType + ": " + stat);
        }
    }

    public void SpriteAndName(MemeCardScriptable memeCard)
    {
        Debug.Log(memeCard);
        _image.sprite = memeCard.sprite;
        _nameTxt.text = memeCard.memeName;
    }
}
