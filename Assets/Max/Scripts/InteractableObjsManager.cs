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

    private void Start()
    {
        //SetClothesToObj();
    }

    private void SetClothesToObj()
    {
        GameObject clothes;
        for (int i = 0; i < _interactableObjs.Length; i++)
        {
            clothes = _clothesManager.GetRandomClothes();
            _interactableObjs[i].GetComponent<InteractableObject>().GetClothes(clothes);
        }
    }
}
