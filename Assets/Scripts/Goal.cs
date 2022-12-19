using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name.Equals("Left wall"))
        {
            GameManager.Instance.AddPoints(2);
        }
        if (this.name.Equals("Rigth wall"))
        {
            GameManager.Instance.AddPoints(1);
        }
    }
}
