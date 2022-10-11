using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //public Animator animator;

    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvulnerable = false;

    public GameObject deathEffect;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }


    public void TakeDamage(int damage)
    {

        if (isInvulnerable)
            return;

        currentHealth -= damage;

        //Play hurt animation
        //animator.SetTrigger("Hurt");
        

        if(currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {

            //die animation
            //animator.SetBool("IsDead", true);

            //disable the enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            if (gameObject.name == "Boss")
            {
                SceneManager.LoadScene("Credits");
            }
            Destroy(gameObject);

        }
    }

}
