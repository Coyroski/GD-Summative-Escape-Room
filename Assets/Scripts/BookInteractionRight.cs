﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractionRight : MonoBehaviour
{
    public GameObject BookRightOpen;
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(BookRightOpen, new Vector3(0f, 0f, 0.01f), Quaternion.identity);
    }
}
