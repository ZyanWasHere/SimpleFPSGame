using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    //Controls player's movement
    public float MovementSpeed;

    //Updates inputs
    void Update()
    {
        MovementUpdate();
    }

    //Updates player's movement, used in Update()
    void MovementUpdate()
    {
        Vector3 PlayerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(PlayerMovement * MovementSpeed * Time.deltaTime);
    }
}
