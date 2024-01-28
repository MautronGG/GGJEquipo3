using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardStats : MonoBehaviour
{
    [SerializeField] MemeCard _memeCard;
    private string _spt = "stpStat";
    private string _fny = "_fnyStat";
    private string _crng = "crngStat";
    
    public void GenerateInformation()
    {
        int type = (int)Mathf.Round(Random.Range(0, 3));
        int stat = (int)Mathf.Round(Random.Range(1, 5));
        if (type == 0)
        {
            _memeCard.SendStats(_crng, stat);
            return;
        }
        if (type == 1)
        {
            _memeCard.SendStats(_fny, stat);
            return;
        }
        if (type == 2)
        {
            _memeCard.SendStats(_spt, stat);
            return;
        }
    }
}
