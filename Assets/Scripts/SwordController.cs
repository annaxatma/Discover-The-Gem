using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public enum MoveDirection
    {
        Left,
        Right,
    }

    public Transform TransformPointA;
    public Transform TransformPointB;
    public float moveSpeed;
    public float currentDirection;
    public float length;
    public MoveDirection moveDirection;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveDirection)
        {
            case MoveDirection.Left:
                currentDirection = (TransformPointA.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.x - TransformPointA.position.x);

                if (length < 0.1)
                {
                    moveDirection = MoveDirection.Right;
                }
                break;
            case MoveDirection.Right:
                currentDirection = (TransformPointB.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.x - TransformPointB.position.x);

                if (length < 0.1)
                {
                    moveDirection = MoveDirection.Left;
                }
                break;
        }


        Move(currentDirection);
    }

    public void Move(float direction)
    {
        Vector3 velocity = rigidbody.velocity;
        velocity.x = direction * moveSpeed;
        rigidbody.velocity = velocity;
        Debug.Log("Player Move!");
    }
}
