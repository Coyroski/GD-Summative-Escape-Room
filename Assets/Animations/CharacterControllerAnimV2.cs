using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAnimV2 : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody2D>();
        anim = gameObject.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
        }
    }
}
