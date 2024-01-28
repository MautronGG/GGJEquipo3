using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] GenerateCards _generateCards;
    private GameObject _memeCard;
    private bool _hasInteracte = false;

    public GameObject Interact()
    {
        Debug.Log(_hasInteracte);
        if (!_hasInteracte)
        {
            _hasInteracte = true;
            _memeCard = FindObjectOfType<GenerateCards>().SendMemeCard();
            return _memeCard;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Recibe la carta de la ropa
    /// </summary>
    /// <param name="clothes"></param>
    public void GetClothes(GameObject clothes)
    {
        
    }
}
