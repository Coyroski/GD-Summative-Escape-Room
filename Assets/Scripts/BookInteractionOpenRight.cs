using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionOpenRight : MonoBehaviour
{
    static public bool rightbookclosed =  false;
    private void OnMouseDown()
    {
        rightbookclosed = true;
        //Menu.SetActive(true);
        Destroy(gameObject);
    }
}
