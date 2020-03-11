using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong : MonoBehaviour
{
    static public bool wrongclosed = false;
    public void OnMouseDown()
    {
        wrongclosed = true;
        Destroy(gameObject);
    }
}
