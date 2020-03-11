using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform NextSpawn;
    
    public int RoomSpawn = 0;
    static int PuzzlePickupAmount = 0;
    static bool GotMissingPiece = false;
    static bool MPInertPickedUp = false;
    static bool HoldingObject = false;
    static bool RugMainDestroyed = false;

    public GameObject Pickups;
    public GameObject MissingKey;
    public GameObject RugMain;
    public GameObject RugMainPulledBack;
    public GameObject RobotSpeech;
    public GameObject InnerThoughtSpeech;
    public GameObject CanvasTrigger;

    public bool speech = false;
    public float RobotSpeechTimer = 240;
    public Text RobotText;

    public bool ITSpeech = false;
    public float ITSpeechTimer = 240;
    public Text ITText;
    public bool endgame = false;

    public AudioSource RobotSound;
    public AudioSource RugSound;
    public AudioSource BatterySound;
    public AudioSource gamewin;

    void Start()
    {
        endgame = false;

        Debug.Log("Welcome to the 1st room");
        if (KeypadInteraction.KeypadEntered == true)
        {
            //Destroy(GameObject.Find("Chest"));
            Instantiate(Pickups, new Vector3(-16.85f, 0.5f, 5.15f), Quaternion.identity);
            Instantiate(Pickups, new Vector3(-15.45f, 0.5f, 5.15f), Quaternion.identity);
            Instantiate(Pickups, new Vector3(-18.25f, 0.5f, 5.15f), Quaternion.identity);
            KeypadInteraction.KeypadEntered = false;
        }
        if (BookController.GotBookKey == true)
        {
            Instantiate(MissingKey, new Vector3(-2, 0.835f, 5.13f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GotMissingPiece == true)
        {
            Destroy(GameObject.Find("Bookcase"));
        }

        if (KeypadInteraction.KeypadDone == true)
        {
            Destroy(GameObject.Find("Chest"));
        }

        if (RugMainDestroyed == true)
        {
            RugMain.gameObject.SetActive(false);
            RugMainPulledBack.gameObject.SetActive(true);
        }
        if (speech == true)
        {
            RobotSpeechSystem();
        }
        if (ITSpeech == true)
        {
            InnerThoughtSpeechSystem();
        }

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
                    HoldingObject = false;
                }

                if (InteractionCheck.gameObject.tag == "MP_Real")
                {
                    Debug.Log("You are already holding an object!");
                    HoldingObject = false;
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
                        endgame = true;
                        ITText.text = "YOU ESCAPED THE ROOM!";
                        gamewin.Play();
                        ITSpeech = true;
                        HoldingObject = false;

                        PuzzlePickupAmount = 0;
                        GotMissingPiece = false;
                        MPInertPickedUp = false;
                        RugMainDestroyed = false;
                        BookController.GotBookKey = false;
                        KeypadInteraction.KeypadEntered = false;
                    }
                }
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (InteractionCheck.gameObject.tag == "PosterTrigger")
                {
                    CanvasTrigger.SetActive(true);
                }
                if (InteractionCheck.gameObject.tag == "PuzzlePickupAmount")
                {
                    PuzzlePickupAmount++;
                    ITText.text = "Picked up " + PuzzlePickupAmount + " batteries.";
                    ITSpeech = true;
                    BatterySound.Play();
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
                    ITText.text = "You got the key!";
                    ITSpeech = true;
                    Destroy(InteractionCheck.gameObject);
                    HoldingObject = true;
                }

                if (InteractionCheck.gameObject.tag == "Robot")
                {
                    RobotSound.Play();
                    if (PuzzlePickupAmount >= 3)
                    {
                        Debug.Log("HERE IS THE RIDDLE");
                        //StartCoroutine(speechcountdown());
                        RobotText.fontSize = 10;
                        RobotText.text = "What You Seek can be Found in the language that is spoken between Rome and Scotland.";
                        speech = true;
                    }
                    else
                    {
                        Debug.Log("This toy seems to be missing batteries");
                        speech = true;
                    }
                }

                if (InteractionCheck.gameObject.tag == "Chest")
                {
                    if (PuzzleGameController.PuzzleComplete == true)
                    {
                        SceneManager.LoadScene("Level2");
               
                    }
                    else
                    {

                        SceneManager.LoadScene("Level2");
                        
                    }
                }

                if (InteractionCheck.gameObject.tag == "PuzzleGame")
                {
                    if (PuzzleGameController.PuzzleComplete == true)
                    {
                        SceneManager.LoadScene("Level0Done");
                    }
                    else
                    {
                        RoomSpawn = 1;
                        CurrentRoom();
                    }
                }
                if (InteractionCheck.gameObject.tag == "MP_TriggerPad")
                {
                    //destroy rugmain
                   
                    RugMainDestroyed = true;
                    RugSound.Play();
                    ITText.text = "Found a trap door!";
                    ITSpeech = true;
                    if (MPInertPickedUp == false && GotMissingPiece == false)
                    {
                        Debug.Log("It is locked...");
                    }
                }
                if (InteractionCheck.gameObject.tag == "Bookcase")
                {
                    if (GotMissingPiece == true)
                    { 
                        Destroy(GameObject.Find("Bookcase")); 
                    }
                    SceneManager.LoadScene("Level3");
                }
            }
        }
    }

    void CurrentRoom()
    {
        if (RoomSpawn == 0)
        {
            //NextSpawn = GameObject.Find("Spawn0").transform;
            //PlayerLocation.position = NextSpawn.position;
            //SceneManager.LoadScene("Level2", LoadSceneMode.Additive);
            SceneManager.LoadScene("Level2");
        }
        if (RoomSpawn == 1)
        {
            SceneManager.LoadScene("Level0");
        }
        if (RoomSpawn == 2)
        {
            NextSpawn = GameObject.Find("Spawn2").transform;
            //PlayerLocation.position = NextSpawn.position;
        }
    }

    /*private IEnumerator speechcountdown()
    {
        float Duration = 3f;
        float TotalTime = 0;
        while(TotalTime <= Duration)
        {
            Debug.Log(speech++);
        }
        yield return null;
    }*/

    void RobotSpeechSystem()
    {
        RobotSpeechTimer--;
        if (RobotSpeechTimer < 240)
        {
            RobotSpeech.SetActive(true);
            if (RobotSpeechTimer < 0)
            {
                RobotSpeechTimer = 240;
                RobotSpeech.SetActive(false);
                speech = false;
            }
        }
    }

    void InnerThoughtSpeechSystem()
    {
        ITSpeechTimer--;
        if (ITSpeechTimer < 240)
        {
            InnerThoughtSpeech.SetActive(true);
            if (ITSpeechTimer < 0)
            {
                ITSpeechTimer = 240;
                InnerThoughtSpeech.SetActive(false);
                ITSpeech = false;
                if (endgame == true)
                {
                    System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); //new program
                    Application.Quit(); //kill current process
                }
            }
        }
    }
}

