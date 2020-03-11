using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong6 : MonoBehaviour
{
    static public bool wrong6closed = false;
    public void OnMouseDown()
    {
        wrong6closed = true;
        Destroy(gameObject);
    }
}