using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is reponsable to move the character in the third person pov.
[RequireComponent(typeof(CharacterController))]   
public class TPMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private float speed = 6f;

    [SerializeField] private float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // It is normalized because you dont want to move faster when you are moving horizontaly and verticaly in the movement  axis.

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //same
        }
    }
}
