using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] ScriptableClothes _scriptable;

    public void Interact()
    {
        Debug.Log(_scriptable.name);
    }
}
