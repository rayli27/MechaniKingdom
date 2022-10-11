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
public class RoomSpawner : MonoBehaviour
{
    public int doorOrientation;
    // 1 -> need bottom door
    // 2 -> need top door
    // 3 -> need left door
    // 4 -> need right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned;
    
    public static int roomCount = 0;

    private float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        roomCount++;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (spawned == false)
        {
            rand = Random.Range(4, 6);
            if (roomCount <= rand)
            {
                if (doorOrientation == 1)
                {
                    // Need to spawn a room with a BOTTOM door.
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                }
                else if (doorOrientation == 2)
                {
                    // Need to spawn a room with a TOP door.
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);

                }
                else if (doorOrientation == 3)
                {
                    // Need to spawn a room with a LEFT door.
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);

                }
                else if (doorOrientation == 4)
                {
                    // Need to spawn a room with a RIGHT door.
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);

                }
            } else
            {
                if (doorOrientation == 1)
                {
                    Instantiate(templates.bottomRooms[0], transform.position, Quaternion.identity);
                }
                else if (doorOrientation == 2)
                {
                    Instantiate(templates.topRooms[0], transform.position, Quaternion.identity);

                }
                else if (doorOrientation == 3)
                {
                    Instantiate(templates.leftRooms[0], transform.position, Quaternion.identity);

                }
                else if (doorOrientation == 4)
                {
                    Instantiate(templates.rightRooms[0], transform.position, Quaternion.identity);
                }
            }
            spawned = true;
        }
    }
    void onTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("SpawnPoint"))
        {
            if (collider.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //make room to fill empty void   
                Instantiate(templates.entryRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collider.gameObject);
            }
            spawned = true;
        }
    }
}
