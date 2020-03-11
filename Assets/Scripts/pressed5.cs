using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressed5 : MonoBehaviour
{
    public bool B5Active = false;
    public void Button5Pressed()
    {
        Debug.Log("button 5 pressed");
        B5Active = true;
    }
}
