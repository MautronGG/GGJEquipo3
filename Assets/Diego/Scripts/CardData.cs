using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public int _value;
    public string _typeString;
    public int _type;

    public void _init(int value, int type)
    {
        _value = value;
        _type = type;

        string[] a = { "tijera", "papel", "piedra" };

        _typeString = a[_type - 1];
    }
}
