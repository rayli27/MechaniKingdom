using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunSecond : StateMachineBehaviour
{

    public float speed = 2.5f;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    Transform player;
    Rigidbody2D rb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(rb.position, player.position) > stoppingDistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(rb.position, player.position) < stoppingDistance && Vector2.Distance(rb.position, player.position) > retreatDistance)
        {
            rb.position = this.rb.position;
        }
        else if (Vector2.Distance(rb.position, player.position) < retreatDistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, rb.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
