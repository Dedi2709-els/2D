using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float playerSpeed;
    public float jumpspeed;

    public bool jumping;

    private bool isFacingRight;
    
    private float move;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move= Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);
        
        if (move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else if (move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if(Input.GetButtonDown("Jump")&& !jumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpspeed));
            jumping = true;
        }

        RunAnimations();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

    void RunAnimations()
    {
        anim.SetFloat("Movement",Mathf.Abs(move));
        anim.SetBool("jumping", jumping);
    }
}
