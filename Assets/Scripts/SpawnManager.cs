using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform PlayerTransform;
    public Transform PlayerLocation;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
        PlayerTransform.position = PlayerLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
