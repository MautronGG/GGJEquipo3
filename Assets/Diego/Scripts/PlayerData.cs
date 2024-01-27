using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _MaxHP = 3;
    private int _hp;

    private void Awake()
    {
        _hp = _MaxHP;
    }

    public void LoseRound()
    {
        _hp--;
    }

    public int GetHP()
    {
        return _hp;
    }
    public int GetMaxHP()
    {
        return _MaxHP;
    }
}
