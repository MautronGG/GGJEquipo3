using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clothes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameTxt;
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _cringeTxt;
    [SerializeField] TextMeshProUGUI _funnyTxt;
    [SerializeField] TextMeshProUGUI _stupidityTxt;

    public void AssigneInfo(ScriptableClothes clothes)
    {
        _nameTxt.text = clothes.name;
        _image = clothes.sprite;
        _cringeTxt.text = "Cringe + " + clothes.cringe.ToString();
        _funnyTxt.text = "Funny + " + clothes.funny.ToString();
        _stupidityTxt.text = "Stupidity + " + clothes.stupidity.ToString();
    }

    public void Test()
    {
        Debug.Log(_nameTxt.text);

    }
}
