using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    //Atributos del HUD
    [SerializeField] private TextMeshProUGUI textIz;
    [SerializeField] private TextMeshProUGUI textDer;

    private void Awake()
    {
        GameManager.Instance.HUDManager = this;
    }

    public void setPoints(int playerNumber, int points)
    {
        if (playerNumber == 1)
        { 
            textIz.text = points.ToString();
        }
        if (playerNumber == 2)
        {
            textDer.text = points.ToString();
        }
    }
}
