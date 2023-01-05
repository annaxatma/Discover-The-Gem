using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public delegate void OnCollisionEnter(Collision2D collision);
    public float moveSpeed;
    public float jumpSpeed;
    private Rigidbody2D rigidbody;
    private Animator anim;
    public bool grounded;

    public OnCollisionEnter onCollisionEnter;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float direction)
    {
        Vector3 velocity = rigidbody.velocity;
        velocity.x = direction * moveSpeed;
        rigidbody.velocity = velocity;

        //flip player sprite
        if (direction == 1)
        {
            transform.localScale = Vector3.one;
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        Vector3 velocity = rigidbody.velocity;
        velocity.y = jumpSpeed;
        rigidbody.velocity = velocity;
        grounded= false;
        anim.SetTrigger("Jump");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnter.Invoke(collision);
        Debug.Log("Collision Object Name: " + collision.gameObject.name);
    }
}