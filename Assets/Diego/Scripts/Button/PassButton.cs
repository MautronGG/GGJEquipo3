using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButton : MonoBehaviour
{
    public void Activate()
    {
        BattleManager.instance.ChangeTurn();
    }
}
