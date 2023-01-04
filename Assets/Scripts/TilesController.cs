using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TilesController : MonoBehaviour
{
    public Transform Eleft;
    public Transform Eright;
    public float currentdirection;
    public MoveDirection movedirection;
    public float length;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (movedirection)
        {
            case MoveDirection.Up:
                currentdirection = (Eleft.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.y - Eleft.position.y);
                break;
            case MoveDirection.Down:
                currentdirection = (Eright.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.y - Eright.position.y);
                break;
        }
    }
}
