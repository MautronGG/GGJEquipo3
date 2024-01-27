using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    // Dbe recibir una tarjeta, no la informacion. Cambiar luego.
    private GameObject _clothesObj;
    private Clothes clothes;

    /// <summary>
    /// Codigo a ejecutar cuando el jugador interactua con el objeto
    /// </summary>
    public void Interact()
    {
        
    }

    public void GetClothes(GameObject clothes)
    {
        _clothesObj = clothes;
        _clothesObj = _clothesObj.GetComponent<Clothes>();
    }
}
