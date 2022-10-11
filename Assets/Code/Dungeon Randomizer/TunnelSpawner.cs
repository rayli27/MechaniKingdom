using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* RoomSpawner.cs
 * 
 * Created: Rodney Johnston on 2/5/2021
 *
 * Purpose: 
 *          
 * Use:     
 */
public class TunnelSpawner : MonoBehaviour
{
    public int tunnelDirection;
    // 1 -> vertical direction
    // 2 -> vertical direction

    private RoomTemplates templates;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }

    void Spawn()
    { 
        if (spawned == false)
        {
            if(tunnelDirection == 1)
            {
                Instantiate(templates.vertTunnel[0], transform.position, Quaternion.identity);
            }
            else if(tunnelDirection == 2)
            {
                Instantiate(templates.horizTunnel[0], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<TunnelSpawner>().spawned == false && spawned == false)
            {
                //make tunnel to fill empty void 
                if (tunnelDirection == 1)
                {
                    Instantiate(templates.vertTunnel[0], transform.position, Quaternion.identity);
                }
                else
                {

                    Instantiate(templates.horizTunnel[0], transform.position, Quaternion.identity);

                }

                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
