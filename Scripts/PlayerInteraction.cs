using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform NextSpawn;
    public Transform PlayerLocation;

    public int RoomSpawn = 0;
    public int PuzzlePickupAmount = 0;
    public bool GotMissingPiece = false;
    public bool MPInertPickedUp = false;
    public bool HoldingObject = false;
    public bool MPDoorUnlocked = false;

    void Start()
    {
        PlayerLocation = GameObject.Find("Player").transform;
        Debug.Log("Welcome to the 1st room");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider InteractionCheck)
    {
        if (HoldingObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (InteractionCheck.gameObject.tag == "Inert")
                {
                    Debug.Log("You are already holding an object!");
                }

                if (InteractionCheck.gameObject.tag == "MP_Real")
                {
                    Debug.Log("You are already holding an object!");
                }

                if (InteractionCheck.gameObject.tag == "Exit")
                {
                    Debug.Log("Door Locked");
                }
                if (InteractionCheck.gameObject.tag == "MP_TriggerPad")
                {
                    if (MPInertPickedUp == true)
                    {
                        Debug.Log("This Seems to be the wrong item...");
                        HoldingObject = false;
                        MPInertPickedUp = false;
                    }
                    if (GotMissingPiece == true)
                    {
                        //MPInertPickedUp = false;
                        Debug.Log("This is the missing piece!");
                        HoldingObject = false;
                        GotMissingPiece = false;
                        MPDoorUnlocked = true;

                    }
                    //if (MPInertPickedUp == false && GotMissingPiece == false)
                    //{
                      //  Debug.Log("Something seems to go here...");
                    //}
                }
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (InteractionCheck.gameObject.tag == "PuzzlePickupAmount")
                {
                    PuzzlePickupAmount++;
                    Debug.Log("Picked up " + gameObject + " " + PuzzlePickupAmount + " times.");
                    Destroy(InteractionCheck.gameObject);
                }

                if (InteractionCheck.gameObject.tag == "Inert")
                {
                    MPInertPickedUp = true;
                    Debug.Log("Picked up an Object (wrong one)");
                    Destroy(InteractionCheck.gameObject);
                    HoldingObject = true;
                }

                if (InteractionCheck.gameObject.tag == "MP_Real")
                {
                    GotMissingPiece = true;
                    Debug.Log("Picked up the missing piece! (real one)");
                    Destroy(InteractionCheck.gameObject);
                    HoldingObject = true;
                }

                if (InteractionCheck.gameObject.tag == "Exit")
                {
                    if (PuzzlePickupAmount >= 3)
                    {
                        Debug.Log("Door Entered (2nd room");
                        RoomSpawn = 0;
                        CurrentRoom();
                        //RoomSpawn = 1; //TEST
                        PuzzlePickupAmount = 0;
                    }

                    //Room Teleporter
                    else if (MPDoorUnlocked == true)
                    {
                        Debug.Log("Door Entered (3rd room)");
                        RoomSpawn = 1;
                        CurrentRoom();
                    }
                    else if (RoomSpawn == 2)
                    {
                        CurrentRoom();
                    }
                    else
                    {
                        Debug.Log("Door Locked");
                    }
                }

                if (InteractionCheck.gameObject.tag == "MP_TriggerPad")
                {
                    if (MPInertPickedUp == false && GotMissingPiece == false)
                    {
                        Debug.Log("Something seems to go here...");
                    }
                }
            }

        }
    }

    void CurrentRoom()
    {
        if (RoomSpawn == 0)
        {
            NextSpawn = GameObject.Find("Spawn0").transform;
            PlayerLocation.position = NextSpawn.position;
        }
        if (RoomSpawn == 1)
        {
            NextSpawn = GameObject.Find("Spawn1").transform;
            PlayerLocation.position = NextSpawn.position;
        }
        if (RoomSpawn == 2)
        {
            NextSpawn = GameObject.Find("Spawn2").transform;
            PlayerLocation.position = NextSpawn.position;
        }
    }
}

