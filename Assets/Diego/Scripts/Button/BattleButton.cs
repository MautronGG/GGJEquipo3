using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    private CardData cardData;


    public void SetData(CardData card)
    {
        cardData = card;
    }

    public CardData getData()
    {
        return cardData;
    }

    public void Activate()
    {

        BattleManager.instance.SetPlayerAttack(cardData);
       
    }
    
}
