using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    // Dbe recibir una tarjeta, no la informacion. Cambiar luego.
    private GameObject _clothesObj;
    private Clothes _clothes;
  public PlayerInventory _inventory;

    /// <summary>
    /// Codigo a ejecutar cuando el jugador interactua con el objeto
    /// </summary>
    public void Interact()
    {
        _clothes = _clothesObj.GetComponent<Clothes>();
        _clothes.Test();
    _inventory.AddToArray(_inventory.m_accesoriesArray, _clothesObj);
    }

    /// <summary>
    /// Recibe la carta de la ropa
    /// </summary>
    /// <param name="clothes"></param>
    public void GetClothes(GameObject clothes)
    {
        _clothesObj = clothes;
    }
}
