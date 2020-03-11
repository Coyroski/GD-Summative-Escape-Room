using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleGameInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource PuzzleRotate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (PuzzleGameController.PuzzleComplete == false)
        {
            PuzzleRotate.Play();
            transform.Rotate(0f, 0f, 90f);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (PuzzleGameController.PuzzleComplete == false)
            {
                PuzzleRotate.Play();
                transform.Rotate(0f, 0f, -90f);
            }
        }
    }
}
