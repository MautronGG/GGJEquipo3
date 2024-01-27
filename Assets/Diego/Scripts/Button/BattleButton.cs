using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    [SerializeField] private int _battleValue;
    [SerializeField] private bool _player;


    public void Activate()
    {
        BattleManager.instance.SetPlayerAttack(_battleValue);
    }
    
}
