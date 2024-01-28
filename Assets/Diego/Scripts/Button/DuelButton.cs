using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelButton : MonoBehaviour
{
    public void Activate()
    {
        BattleManager.instance.Resolve();
    }
}
