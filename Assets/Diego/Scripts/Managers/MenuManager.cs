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
    [SerializeField] private GameObject _deck;
    [SerializeField] private GameObject _mainCard;
    [SerializeField] private GameObject _card;
    [SerializeField] private GameObject _passTurn;

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
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Player2Turn)
        {
            _passTurn.gameObject.SetActive(false);
        }
        if (State == BattleState.Resolve)
        {

            _playerAttack.SetActive(true);
            _enemyAttack.SetActive(true);
        }
        if (State == BattleState.End)
        {

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
    public void CreateDeck(List<GameObject> Deck, List<GameObject> MainCard)
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            GameObject a = Instantiate(_card, _deck.transform);
            a.GetComponent<BattleButton>().SetData(Deck[i].GetComponent<CardData>());
            a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;  
        }

        for (int i = 0; i < MainCard.Count; i++)
        {
            GameObject a = Instantiate(_card, _mainCard.transform);
            a.GetComponent<BattleButton>().SetData(MainCard[i].GetComponent<CardData>());
            a.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponent<BattleButton>().getData()._value + "/" + a.GetComponent<BattleButton>().getData()._type;
        }


    }
    private void Clean()
    {
        foreach (Transform child in _deck.transform) 
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in _mainCard.transform)
        {
            Destroy(child.gameObject);
        }

    }
    public void PassTurn()
    {
        Clean();
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
