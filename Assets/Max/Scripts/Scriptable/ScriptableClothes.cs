using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableClothes")]
public class ScriptableClothes : ScriptableObject
{
    [SerializeField] Image _sprite;
    [SerializeField] int _cringe;
    [SerializeField] int _funny;
    [SerializeField] int _stupidity;
}
