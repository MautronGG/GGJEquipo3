using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _result;
    [SerializeField] private GameObject _playerAttack;
    [SerializeField] private GameObject _enemyAttack;
    [SerializeField] private GameObject _playerhp;
    [SerializeField] private GameObject _enemyhp;
    [SerializeField] private GameObject _player1Deck;
    [SerializeField] private GameObject _player1MainCard;
    [SerializeField] private GameObject _player2Deck;
    [SerializeField] private GameObject _player2MainCard;
    [SerializeField] private GameObject _card;
    [SerializeField] private GameObject _passTurn;
    [SerializeField] private GameObject _turn;

    private void Awake()
    {
        instance = this;
        BattleManager.OnBattleStateChanged += MenuManagement;
    }

    void OnDestroy()
    {
        BattleManager.OnBattleStateChanged -= MenuManagement;
    }

    private void MenuManagement(BattleState State)
    {
        if (State == BattleState.Start)
        {

        }
        if (State == BattleState.Player1Turn)
        {
            _player1Deck.SetActive(true);
            _player1MainCard.SetActive(true);
            _player2Deck.SetActive(false);
            _player2Deck.SetActive(false);
            _turn.GetComponent<TextMeshProUGUI>().text = "Player 1 turn";
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Player2Turn)           
        {
            _player1Deck.SetActive(false);
            _player1MainCard.SetActive(false);
            _player2Deck.SetActive(true);
            _player2Deck.SetActive(true);
            _turn.GetComponent<TextMeshProUGUI>().text = "Player 2 turn";
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Resolve)
        {
            _playerAttack.SetActive(true);
            _enemyAttack.SetActive(true);
        }
        if (State == BattleState.End)
        {
            _turn.gameObject.SetActive(false);  
        }

    }

    public void UpdateAttack(int playerAttack, int enemyAttack)
    {
        _playerAttack.GetComponent<TextMeshProUGUI>().text = playerAttack.ToString();
        _enemyAttack.GetComponent<TextMeshProUGUI>().text = enemyAttack.ToString();
    }

    public void UpdateHP(int playerHP, int playerMaxHP, int enemyHP, int enemyMaxHP) 
    {
        _playerhp.GetComponent<TextMeshProUGUI>().text = playerHP + " / " + playerMaxHP;
        _enemyhp.GetComponent<TextMeshProUGUI>().text = enemyHP + " / " + enemyMaxHP;

    }
    public void CreateDeck(List<GameObject> Deck, List<GameObject> MainCard,GameObject player)
    {
        if ( player.gameObject.name == "Player1")
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                GameObject a = Instantiate(_card, _player1Deck.transform);
                a.GetComponent<BattleButton>().SetData(Deck[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;
            }

            for (int i = 0; i < MainCard.Count; i++)
            {
                GameObject a = Instantiate(_card, _player1MainCard.transform);
                a.GetComponent<BattleButton>().SetData(MainCard[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;
            }
        }
        
        else if (player.gameObject.name == "Player2")
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                GameObject a = Instantiate(_card, _player2Deck.transform);
                a.GetComponent<BattleButton>().SetData(Deck[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;
            }

            for (int i = 0; i < MainCard.Count; i++)
            {
                GameObject a = Instantiate(_card, _player2MainCard.transform);
                a.GetComponent<BattleButton>().SetData(MainCard[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;
            }
        }


    }
    public void PassTurn()
    {
        _passTurn.gameObject.SetActive(true);
    }
    
    public void End(bool winner)
    {
        _result.gameObject.SetActive(true);

        if (winner)
        {
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "P1 Wins";
        }

        else
        {
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "P2 Wins";
        }

    }

}
