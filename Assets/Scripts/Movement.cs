using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Reference to the speed and character controller on the player.
    [Header("Player Components")]
    public CharacterController controller;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Grabbing inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //How is he going to move?
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}