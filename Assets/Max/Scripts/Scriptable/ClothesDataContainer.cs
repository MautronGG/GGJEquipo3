using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contenedor de los datos de la ropa que guarda los ScriptableClothes
// y envia la informacion a CothesManager.
public class ClothesDataContainer : MonoBehaviour
{
    [SerializeField] ScriptableClothes[] _scriptableClothes;

    public int GetListLenght()
    {
        return _scriptableClothes.Length;
    }

    public ScriptableClothes GetClotheInIndex(int index)
    {
        return _scriptableClothes[index];
    }
}
