using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleGameExit : MonoBehaviour
{
    // Start is called before the first frame update
    public void PGButtonPressed()
    {
        SceneManager.LoadScene("Level");
    }
}
