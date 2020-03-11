using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong3 : MonoBehaviour
{
    static public bool wrong3closed = false;
    public void OnMouseDown()
    {
        wrong3closed = true;
        Destroy(gameObject);
    }
}