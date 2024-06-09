using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJMController : MonoBehaviour
{
    public PlayerMovement pm;
    public VariableJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pm.vert = joystick.Vertical;
        pm.hort = joystick.Horizontal;
    }
}
