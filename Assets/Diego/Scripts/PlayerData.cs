using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private List<GameObject> _deck;
    private List<GameObject> _mainCard;
    [SerializeField] private GameObject _card;
    [SerializeField] private int _MaxHP = 3;
    private int _hp;

    private void Awake()
    {
        _hp = _MaxHP;
    }


    public void CreateMainCard()
    {
        int b = 1;
        _mainCard = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject card = Instantiate(_card, gameObject.transform);
            card.GetComponent<CardData>()._init(Random.Range(2, 7), b);
            _mainCard.Add(card);
            b++;
        }
    }

    public List<GameObject> GetMainCard()
    {
        return _mainCard;
    }

    public void CreateDeck()
    {
        int a = Random.Range(2, 7);
        _deck = new List<GameObject>();

        for (int i = 0; i < a; i++)
        {
            GameObject card = Instantiate(_card,gameObject.transform);
            card.GetComponent<CardData>()._init(Random.Range(2, 7), Random.Range(1, 4));
            _deck.Add(card);
            

        }
    }

    public List<GameObject> GetDeck()
    {
        return _deck;
    }

    public void LoseRound(int dmg)
    {
        _hp = _hp-dmg;
        if (_hp < 0)
        {
            _hp = 0;
        }
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
