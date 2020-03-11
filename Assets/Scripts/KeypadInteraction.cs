using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadInteraction : MonoBehaviour
{
    static public bool KeypadEntered = false;
    static public bool KeypadDone = false;
    public int NumberTimesPressed;
    public bool B2 = false;
    public bool B5 = false;
    public bool B6 = false;
    public bool playsoundactive = true;

    public GameObject unlocktext;
    public AudioSource winsound;

    // Start is called before the first frame update
    void Start()
    {
        //B2 = GameObject.Find("nameOfObjectYourScriptIsOn").GetComponent<move>().speed
      
    }

    // Update is called once per frame
    void Update()
    {
        B2 = gameObject.GetComponent<pressed2>().B2Active;
        B5 = gameObject.GetComponent<pressed5>().B5Active;
        B6 = gameObject.GetComponent<pressed6>().B6Active;
        TestCorrectKey();
    }

    void TestCorrectKey()
    {
        if (B2 == true)
        {
            if (B5 == true)
            {
                if (B6 == true)
                {
                    KeypadDone = true;
                    KeypadEntered = true;
                }

            }
        }
        if (KeypadDone == true)
        {
            unlocktext.gameObject.SetActive(true);
            NumberTimesPressed = 0;
            if (playsoundactive == true)
            {
                winsound.PlayOneShot(winsound.clip, 1);
                playsoundactive = false;
            }
        }

    }

    public void EnteredCorrectKey()
    {
        Debug.Log("back to main level");
        SceneManager.LoadScene("Level");
        //SceneManager.UnloadSceneAsync("Level2");
    }
}
