using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public int _value;
    public int _type;

    public void _init(int value, int type)
    {
        _value = value;
        _type = type;
    }
}
