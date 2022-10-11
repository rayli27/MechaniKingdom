using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;

    public float bulletForce = 20f;
    public int damage = 20;

    public float cooldown1 = 0.5f;
    bool isCooldown = false;

    public Image abilityImage1;
    //public bool isShooting;

    private void Start()
    {
        abilityImage1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();   
    }

    void Shoot()
    {

        if (Input.GetMouseButtonDown(0) && isCooldown == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            animator.SetBool("Shoot", true);

            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }
        

        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0.5)
            {
                animator.SetBool("Shoot", false);
            }

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;

            }
        }



    }

    public int getDamage()
    {
        return damage;
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint == null)
            return;

        Gizmos.DrawWireSphere(firePoint.position, 2);
    }
}
