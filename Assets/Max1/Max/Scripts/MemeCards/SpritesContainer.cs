using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesContainer : MonoBehaviour
{
    [SerializeField] MemeCardScriptable[] _memes;

    public MemeCardScriptable SendRandomMeme()
    {
        int index = Random.Range(0, _memes.Length);
        return _memes[index];
    }
}
