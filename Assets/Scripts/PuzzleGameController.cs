using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameController : MonoBehaviour
{
    public GameObject puzzletextcomplete;
    public AudioSource winsound;
    [SerializeField]
    private Transform[] pictures;

    public static bool PuzzleComplete = false;
    public bool playwinsound = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pictures[0].rotation.z == 0 &&
            pictures[1].rotation.z == 0 &&
            pictures[2].rotation.z == 0 &&
            pictures[3].rotation.z == 0 &&
            pictures[4].rotation.z == 0 &&
            pictures[5].rotation.z == 0 &&
            pictures[6].rotation.z == 0 &&
            pictures[7].rotation.z == 0 &&
            pictures[8].rotation.z == 0)
        {
            PuzzleComplete = true;
            Debug.Log("puzzle complete");
            puzzletextcomplete.SetActive(true);
            if (playwinsound == true)
            {
                winsound.Play();
                playwinsound = false;
            }
        }
    }
}
