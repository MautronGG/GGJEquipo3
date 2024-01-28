using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "MemeCardScriptable")]
public class MemeCardScriptable : ScriptableObject
{
    public string memeName;
    public Sprite sprite;
}
