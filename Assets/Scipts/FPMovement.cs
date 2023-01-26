using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

//this scipt is reponsable to move the character in the first person pov.
[RequireComponent(typeof(CharacterController))]
public class FPMovement : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    private CharacterController fPcontroller;
    void Start()
    {
        fPcontroller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        fPcontroller.Move(move * speed * Time.deltaTime);

    }
}
