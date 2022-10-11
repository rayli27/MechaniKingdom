using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;

    private void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {

            if (GameObject.Find("PlayerTest") != false && i < PlayerMovement.instance.currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }

    }


}
