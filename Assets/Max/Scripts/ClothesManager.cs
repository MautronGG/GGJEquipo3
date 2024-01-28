using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que recibe y asigna la informacion de la ropa a los
// prefabs de las prendas.
public class ClothesManager : MonoBehaviour
{
    [SerializeField] ClothesDataContainer _clothesDataContainer;
    [SerializeField] GameObject _clothesPrefab;
    [SerializeField] GameObject[] _clothesPrefabs;

    private void Awake()
    {
        _clothesPrefabs = new GameObject[_clothesDataContainer.GetListLenght()];
        SetInformation();
    }

    private void SetInformation()
    {
        ScriptableClothes data = null;
        for (int i = 0; i < _clothesPrefabs.Length; i++)
        {
            data = _clothesDataContainer.GetClotheInIndex(i);
            _clothesPrefabs[i] = Instantiate(_clothesPrefab);
            _clothesPrefabs[i].GetComponent<Clothes>().AssigneInfo(data);
        }
    }

    public GameObject GetRandomClothes()
    {
        int index = Random.Range(0, _clothesPrefabs.Length);
        return _clothesPrefabs[index];
    }
}
