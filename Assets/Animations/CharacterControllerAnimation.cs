using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAnimation : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
        anim = gameObject.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("leftUp", true);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", true);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", true);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", false);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("leftUp", false);
            anim.SetBool("leftDown", false);
            anim.SetBool("RightUp", true);
            anim.SetBool("Rightdown", false);
            anim.SetBool("Idle", false);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
