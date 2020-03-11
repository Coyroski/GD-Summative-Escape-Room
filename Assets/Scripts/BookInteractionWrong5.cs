using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong5 : MonoBehaviour
{
    static public bool wrong5closed = false;
    public void OnMouseDown()
    {
        wrong5closed = true;
        Destroy(gameObject);
    }
}