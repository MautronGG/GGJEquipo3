using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableClothes")]
public class ScriptableClothes : ScriptableObject
{
    public string clothesName;
    public Image sprite;
    public int cringe;
    public int funny;
    public int stupidity;
}
