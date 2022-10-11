using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public Image[] mechHearts;


    public Image mechHeartBW1;
    public Image mechHeartBW2;
    public Image redHeart;

    public Animator animator;

    void Start()
    {
        mechHeartBW1.fillAmount = 0;
        mechHeartBW2.fillAmount = 0;
        redHeart.fillAmount = 0;
    }

    void Update()
    {
            if (gameObject.GetComponent<Enemy>().currentHealth == 0)
            {
                SceneManager.LoadScene("Credits");
            }
            if (gameObject.GetComponent<Enemy>().currentHealth <= 0)
            {
                animator.SetBool("Defeated", true);
            }

        if (gameObject.GetComponent<Enemy>().currentHealth >= (gameObject.GetComponent<Enemy>().maxHealth * 2 / 3))
            {
                mechHeartBW1.fillAmount = ((float) (gameObject.GetComponent<Enemy>().maxHealth - gameObject.GetComponent<Enemy>().currentHealth)) / (gameObject.GetComponent<Enemy>().maxHealth / 3);
            }
            else if (gameObject.GetComponent<Enemy>().currentHealth >= (gameObject.GetComponent<Enemy>().maxHealth / 3))
            {
                GetComponent<Animator>().SetBool("IsEnraged", true);
                mechHeartBW1.fillAmount = 1;
                mechHeartBW2.fillAmount = ((float) ((gameObject.GetComponent<Enemy>().maxHealth * 2 / 3) - gameObject.GetComponent<Enemy>().currentHealth)) / (gameObject.GetComponent<Enemy>().maxHealth / 3);
            }
            else
            {
                GetComponent<Animator>().SetBool("IsSuperEnraged", true);
                mechHeartBW1.fillAmount = 1;
                mechHeartBW2.fillAmount = 1;
                redHeart.fillAmount = (float)((gameObject.GetComponent<Enemy>().maxHealth / 3) - gameObject.GetComponent<Enemy>().currentHealth) / (gameObject.GetComponent<Enemy>().maxHealth / 3);
            }

    }
}
