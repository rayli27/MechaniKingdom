using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public bool enemyInside = false;
    private void OnTriggerStay(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            enemyInside = true;
        }
    }

    private void TriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInside = true;
        }
    }
}
