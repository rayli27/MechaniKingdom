using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public int floor;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject entryRoom;

    public GameObject[] vertTunnel;
    public GameObject[] horizTunnel;

    public GameObject[] vertDoor;
    public GameObject[] horizDoor;

    public GameObject staircase;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedEntity = false;

    void Update()
    {
        //while no boss has been spaned or the wait time has finished
        if (waitTime <= 0 && spawnedEntity == false)
        {

            //spawn boss or portal
            for (int i = 0; i < rooms.Count; i++)
            {

                if (i == rooms.Count - 1)
                {
                    
                    Instantiate(staircase, rooms[i].transform.position, Quaternion.identity);
                    
                    spawnedEntity = true;

                }

            }

        }
        else
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }

        }
    }
}
