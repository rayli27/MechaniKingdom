using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public int maxHealth = 5;
    public int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    int damage = 1;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;

    Vector2 movement;
    Vector2 mousePos;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //UserInput
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        //change the way the character is looking
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
      
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damage);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Health")
        {
            Debug.Log("Hit");
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
            other.gameObject.SetActive(false);
        }
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        //animator.SetTrigger("Hurt");


        if (currentHealth <= 0)
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

            hearts[0].enabled = false;

            FindObjectOfType<GameManager>().EndGame();
            Destroy(gameObject);
            

        }
    }
}
