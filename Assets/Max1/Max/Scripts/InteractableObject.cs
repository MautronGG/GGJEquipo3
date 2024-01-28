using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] GenerateCards _generateCards;
    [SerializeField] PlayerInventory _inventory;
    private GameObject _memeCard;

    /// <summary>
    /// 
    /// </summary>
    public void Interact()
    {
        _memeCard = _generateCards.SendMemeCard();
        _inventory.AddToArray(_inventory.m_memeCardsArray, _memeCard);
    }

    /// <summary>
    /// Recibe la carta de la ropa
    /// </summary>
    /// <param name="clothes"></param>
    public void GetClothes(GameObject clothes)
    {
        
    }
}
