using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que recibe objetos aleatorios de ClothesManager y los asigna
// a un InteractableObject
public class InteractableObjsManager : MonoBehaviour
{
    [SerializeField] ClothesManager _clothesManager;
    // Lista de todos los objetos interactivos disponibles
    [SerializeField] GameObject[] _interactableObjs;

    private void AssigneClothes()
    {
        GameObject clothesObj;
        for (int i = 0; i < _interactableObjs.Length; i++)
        {
            clothesObj = _clothesManager.GetRandomClothes();
            _interactableObjs[i].GetComponent<InteractableObject>().GetClothes(clothesObj);
        }
    }
}
