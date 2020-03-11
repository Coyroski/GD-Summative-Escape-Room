using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionWrong2 : MonoBehaviour
{
    static public bool wrong2closed = false;
    public void OnMouseDown()
    {
        wrong2closed = true;
        Destroy(gameObject);
    }
}
