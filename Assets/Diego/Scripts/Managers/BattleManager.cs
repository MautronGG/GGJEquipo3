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

    [SerializeField] GameObject _player1;
    private PlayerData _player1Data;
    [SerializeField] GameObject _player2;
    private PlayerData _player2Data;
    private CardData _player1Attack;
    private CardData _player2Attack;
    private int _player1MaxHP;
    private int _player2MaxHP;
    private bool _p1Win;




    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _player1MaxHP = _player1.GetComponent<PlayerData>().GetMaxHP();
        _player2MaxHP = _player2.GetComponent<PlayerData>().GetMaxHP();
        UpdateBattleState(StartingState);
    }
    
    public void UpdateBattleState(BattleState newState)
    {
        State = newState;

        switch (State)
        {
            case BattleState.Start:
                MenuManager.instance.UpdateHP(_player1.GetComponent<PlayerData>().GetHP(), _player1MaxHP, _player2.GetComponent<PlayerData>().GetHP(), _player2MaxHP);
                _player1.GetComponent<PlayerData>().CreateDeck();
                _player2.GetComponent<PlayerData>().CreateDeck();
                _player1.GetComponent<PlayerData>().CreateMainCard();
                _player2.GetComponent<PlayerData>().CreateMainCard();
                UpdateBattleState(BattleState.Player1Turn);
                break;
            case BattleState.Player1Turn:
                PlayerTurn(_player1);
                break;
            case BattleState.Player2Turn:
                PlayerTurn(_player2);
                break;
            case BattleState.Resolve:
                Resolve();
                break;
            case BattleState.End:
                MenuManager.instance.End(_p1Win);
                break;

        }
        OnBattleStateChanged?.Invoke(newState);
    }
    
    public void SetPlayerAttack(CardData cardData)
    {
        if (State == BattleState.Player1Turn)
        {
            _player1Attack = cardData;
            MenuManager.instance.PassTurn();
        }

        else if (State == BattleState.Player2Turn)
        {
            _player2Attack = cardData;
            instance.UpdateBattleState(BattleState.Resolve);
        }

    }


    private void PlayerTurn(GameObject player)
    {
        MenuManager.instance.CreateDeck(player.GetComponent<PlayerData>().GetDeck(), player.GetComponent<PlayerData>().GetMainCard());
    }

    public void ChangeTurn()
    {
        if (State == BattleState.Resolve)
        {
            instance.UpdateBattleState(BattleState.Player1Turn);
        }
        else
        {
            {
                instance.UpdateBattleState(BattleState.Player2Turn);
            }
        }
    }
    
    private void Resolve()
    {
        _player1Data = _player1.GetComponent<PlayerData>();
        _player2Data = _player2.GetComponent<PlayerData>();
        if (_player1Attack._type == 1 &&  _player2Attack._type == 2 || _player1Attack._type == 2 && _player2Attack._type == 3 || _player1Attack._type == 3 && _player2Attack._type == 1) 
        { 
            _player2Data.LoseRound(_player1Attack._value);
        }

        else if (_player1Attack._type == _player2Attack._type)
        {

        }

        else
        {
            _player1Data.LoseRound(_player2Attack._value);
        }

        MenuManager.instance.UpdateHP(_player1.GetComponent<PlayerData>().GetHP(), _player1MaxHP, _player2.GetComponent<PlayerData>().GetHP(), _player2MaxHP);

        if (_player1Data.GetHP() == 0)
        {
            UpdateBattleState(BattleState.End);
            _p1Win = false;
        }

        if(_player2Data.GetHP() == 0)
        {
            UpdateBattleState(BattleState.End);
            _p1Win = true;
        }

        else
        {
            MenuManager.instance.PassTurn();
        }

    }


}
public enum BattleState
{
    Start,
    Player1Turn,
    Player2Turn,
    Resolve,
    End
}
