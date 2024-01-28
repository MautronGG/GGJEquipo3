using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image bar;
    public GameObject life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (float)life.GetComponent<PlayerData>().GetHP() / (float)life.GetComponent<PlayerData>().GetMaxHP();
        Debug.Log(life.GetComponent<PlayerData>().GetHP());
        Debug.Log(life.GetComponent<PlayerData>().GetMaxHP());
    }
}
