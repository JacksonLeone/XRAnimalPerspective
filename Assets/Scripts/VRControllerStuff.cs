using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerStuff : MonoBehaviour
{
    public CharacterController controller;
    private bool start = true;
    private Vector3 lastPos;
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    private void Update()
    {
        if (start)
        {
            start = false;
            lastPos = transform.position;
            return;
        }
        //controller.Move(new Vector3 (0, -9.81f * Time.deltaTime, 0));
        Vector3 pos = transform.position;
        transform.position = lastPos;
        Vector3 delta = pos - lastPos;
        controller.Move(delta + gravity * Time.deltaTime);
        lastPos = transform.position;

        /*
         * IDEA: 
         * Store last frame position
         * get this frame's delta
         * move pack to last position
         * use move function to get to the new position
         * store current position as last position
         * make sure this script is set to run after all others or do this in lateupdate
         */
    }
}
