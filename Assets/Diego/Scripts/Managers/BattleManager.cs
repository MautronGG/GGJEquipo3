using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
// 1. Player selcts 123, bot selects 123, lose or win

    public static BattleManager instance;
    public BattleState StartingState;
    public BattleState State;
    public static event Action<BattleState> OnBattleStateChanged;

    [SerializeField] GameObject _player;
    private PlayerData _playerData;
    [SerializeField] GameObject _enemy;
    private PlayerData _enemyData;
    private int _playerAttack;
    private int _enemyAttack;
    private int _playerMaxHP;
    private int _enemyMaxHP;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _playerMaxHP = _player.GetComponent<PlayerData>().GetMaxHP();
        _enemyMaxHP = _player.GetComponent<PlayerData>().GetMaxHP();
        UpdateBattleState(StartingState);
    }
    
    public void UpdateBattleState(BattleState newState)
    {
        State = newState;

        switch (State)
        {
            case BattleState.start:
                MenuManager.instance.UpdateHP(_player.GetComponent<PlayerData>().GetHP(), _playerMaxHP,_enemy.GetComponent<PlayerData>().GetHP(), _enemyMaxHP);
                UpdateBattleState(BattleState.playerTurn);
                break;
            case BattleState.playerTurn:
                MenuManager.instance.HideButtons();
                break;
            case BattleState.enemyTurn:
                _enemyAttack = UnityEngine.Random.Range(1, 4);
                MenuManager.instance.UpdateAttack(_playerAttack,_enemyAttack);
                UpdateBattleState(BattleState.Resolve);
                break;
            case BattleState.Resolve:
                Resolve();
                break;
            case BattleState.Win:
                break;
            case BattleState.Lose:
                break;

        }
        OnBattleStateChanged?.Invoke(newState);
    }

    public void SetPlayerAttack(int attack)
    {
        _playerAttack = attack;
        instance.UpdateBattleState(BattleState.enemyTurn);
    }

    private void Resolve()
    {
        _playerData = _player.GetComponent<PlayerData>();
        _enemyData = _enemy.GetComponent<PlayerData>();
        if (_playerAttack == 1 &&  _enemyAttack == 2 || _playerAttack == 2 && _enemyAttack == 3 || _playerAttack == 3 && _enemyAttack == 1) 
        { 
            _enemyData.LoseRound();
        }

        else if (_playerAttack ==  _enemyAttack)
        {

        }

        else
        {
            _playerData.LoseRound();
        }

        MenuManager.instance.UpdateHP(_player.GetComponent<PlayerData>().GetHP(), _playerMaxHP, _enemy.GetComponent<PlayerData>().GetHP(), _enemyMaxHP);

        if (_playerData.GetHP() == 0)
        {
            UpdateBattleState(BattleState.Lose);
        }
        
        if (_enemyData.GetHP() == 0)
        {
            UpdateBattleState(BattleState.Win);
        }

        else
        {
            UpdateBattleState(BattleState.playerTurn);
        }

    }


}
public enum BattleState
{
    start,
    playerTurn,
    enemyTurn,
    Resolve,
    Win,
    Lose,
}
