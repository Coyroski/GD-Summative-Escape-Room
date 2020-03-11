using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterExit : MonoBehaviour
{
    public GameObject poster;
    public void OnMouseDown()
    {
        poster.SetActive(false);
    }

}

