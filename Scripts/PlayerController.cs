using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ORIGINAL CONTENT DONUT STEEL
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _hori;
    private float _verti;
    private float _runspeed = 1f;

    public float moveSpeedMultiplier = 4f;
    public float runSpeedMultiplier = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //Player run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _runspeed = runSpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _runspeed = 1f;
        }

        //Player movement forwards and side to side
        _hori = Input.GetAxis("Horizontal") * moveSpeedMultiplier * _runspeed * Time.deltaTime;
        _verti = Input.GetAxis("Vertical") * moveSpeedMultiplier * _runspeed * Time.deltaTime;
        transform.Translate(new Vector3(_hori, 0f, _verti));
    }




}
