using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject _playerCombatMenu;
    [SerializeField] private GameObject _enemyCombatMenu;
    [SerializeField] private GameObject _result;
    [SerializeField] private GameObject _playerAttack;
    [SerializeField] private GameObject _enemyAttack;
    [SerializeField] private GameObject _playerhp;
    [SerializeField] private GameObject _enemyhp;

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
        if (State == BattleState.start)
        {

        }
        if (State == BattleState.playerTurn)
        {

        }
        if (State == BattleState.enemyTurn)
        {
            _playerCombatMenu?.SetActive(false);
        }
        if (State == BattleState.Resolve)
        {
            _playerCombatMenu.SetActive(true);
            _playerAttack.SetActive(true);
            _enemyAttack.SetActive(true);
        }
        if (State == BattleState.Win)
        {
            _result.GetComponent<TextMeshProUGUI>().text = "Winner";
            _result.SetActive(true);
            _playerCombatMenu.SetActive(false);
            _enemyCombatMenu.SetActive(false);
        }
        if (State == BattleState.Lose)
        {
            _result.GetComponent<TextMeshProUGUI>().text = "Loser";
            _result.SetActive(true);
            _playerCombatMenu.SetActive(false);
            _enemyCombatMenu.SetActive(false);
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


    public void HideButtons()
    {
        _playerCombatMenu.gameObject.SetActive(true);
    }

}
