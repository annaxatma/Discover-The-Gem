using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static TilesController;

public class TilesController : MonoBehaviour
{
    public enum MoveDirection
    {
        Up,
        Down,
    }

    public Transform Up;
    public Transform Down;
    public float currentdirection;
    public MoveDirection movedirection;
    public float moveSpeed;
    public float length;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (movedirection)
        {
            case MoveDirection.Down:
                currentdirection = (Up.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.y - Down.position.y);
                if (length < 0.1)
                {
                    movedirection = MoveDirection.Up;
                }
                break;
            case MoveDirection.Up:
                currentdirection = (Down.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.y - Up.position.y);
                if (length < 0.1)
                {
                    movedirection = MoveDirection.Down;
                }
                break;
        }

        Move(currentdirection);
    }

    public void Move(float direction)
    {
        Vector3 velocity = rigidbody.velocity;
        velocity.y = direction * moveSpeed;
        rigidbody.velocity = velocity;
        Debug.Log("Tile Move!");
    }
}
