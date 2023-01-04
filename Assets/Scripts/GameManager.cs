using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerController.Move(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerController.Move(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.Jump();
        }
        else
        {
            playerController.Move(0);
        }
    }
}