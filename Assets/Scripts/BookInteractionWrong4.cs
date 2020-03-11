using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong4 : MonoBehaviour
{
    static public bool wrong4closed = false;
    public void OnMouseDown()
    {
        wrong4closed = true;
        Destroy(gameObject);
    }
}