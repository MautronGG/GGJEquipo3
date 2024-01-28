using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _result;
    [SerializeField] private GameObject _player1Attack;
    [SerializeField] private GameObject _player2Attack;
    [SerializeField] private GameObject _playerhp;
    [SerializeField] private GameObject _enemyhp;
    [SerializeField] private GameObject _player1Deck;
    [SerializeField] private GameObject _player1MainCard;
    [SerializeField] private GameObject _player2Deck;
    [SerializeField] private GameObject _player2MainCard;
    [SerializeField] private GameObject _card;
    [SerializeField] private GameObject _passTurn;
    [SerializeField] private GameObject _turn;
    [SerializeField] private GameObject _roundWinner;
    [SerializeField] private GameObject _duel;
    [SerializeField] private GameObject _duelbutton;

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
            _player2MainCard.SetActive(false);
            _duel.SetActive(false);
            _turn.GetComponent<TextMeshProUGUI>().text = "Player 1 turn";
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Player2Turn)           
        {
            _player1Deck.SetActive(false);
            _player1MainCard.SetActive(false);
            _player2Deck.SetActive(true);
            _player2MainCard.SetActive(true);
            _turn.GetComponent<TextMeshProUGUI>().text = "Player 2 turn";
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Resolve)
        {
            _turn.GetComponent<TextMeshProUGUI>().text = "DUEL";
            _player1Deck.SetActive(false);
            _player1MainCard.SetActive(false);
            _player2Deck.SetActive(false);
            _player2MainCard.SetActive(false);
            _duel.SetActive(true);
            _duelbutton.SetActive(true);
            _player1Attack.GetComponent<TextMeshProUGUI>().text = "?";
            _player2Attack.GetComponent<TextMeshProUGUI>().text = "?";
        }
        if (State == BattleState.End)
        {
            _turn.gameObject.SetActive(false);  
        }

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
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + " / " + a.GetComponent<BattleButton>().getData()._typeString;
            }

            for (int i = 0; i < MainCard.Count; i++)
            {
                GameObject a = Instantiate(_card, _player1MainCard.transform);
                a.GetComponent<BattleButton>().SetData(MainCard[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + " / " + a.GetComponent<BattleButton>().getData()._typeString;
            }
        }
        
        else if (player.gameObject.name == "Player2")
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                GameObject a = Instantiate(_card, _player2Deck.transform);
                a.GetComponent<BattleButton>().SetData(Deck[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + " / " + a.GetComponent<BattleButton>().getData()._typeString;
            }

            for (int i = 0; i < MainCard.Count; i++)
            {
                GameObject a = Instantiate(_card, _player2MainCard.transform);
                a.GetComponent<BattleButton>().SetData(MainCard[i].GetComponent<CardData>());
                a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + " / " + a.GetComponent<BattleButton>().getData()._typeString;
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
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "P1 CAMPEÓN";
        }

        else
        {
            _result.GetComponentInChildren<TextMeshProUGUI>().text = "P2 CAMPEÓN";
        }

    }

    public void Duel(CardData Player1, CardData Player2)
    {
        StartCoroutine(CardDuel(Player1, Player2));
    }

    public void SetWinner(GameObject winner = null)
    {
        if ( winner == null)
        {
            _roundWinner.GetComponent<TextMeshProUGUI>().text = "Empate";
        }
        else
        {
            _roundWinner.GetComponent<TextMeshProUGUI>().text = winner.name + " ganó esta ronda";
        }
            
    }

    IEnumerator CardDuel(CardData Player1, CardData Player2)
    {
        _player1Attack.SetActive(true);
        _player2Attack.SetActive(true);
        _duelbutton.SetActive(false);

        _player1Attack.GetComponent<TextMeshProUGUI>().text = Player1._value + " / " + Player1._typeString;
        _player2Attack.GetComponent<TextMeshProUGUI>().text = Player2._value + " / " + Player2._typeString;

        yield return new WaitForSeconds(2f);
    }
}
