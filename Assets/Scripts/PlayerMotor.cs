using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private float speed = 5.0f;

    private Vector3 moveVector;

    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;

    private bool isDead = false;

    private float startTime;

	// Use this for initialization
	void Start () {
        
        controller = GetComponent<CharacterController>();
        startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity*Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector*Time.deltaTime);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, -1.25f, 1.25f);
        transform.position = clampedPosition;

        //transform.position.x = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);

	}

    public void SetSpeed (float modifier) {
        
        speed = 5.0f + modifier;

    }

    void OnControllerColliderHit (ControllerColliderHit hit) {

        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
        {
            Death();
        }

    }

    void Death () {

        isDead = true;
        GetComponent<Score>().OnDeath();

    }
}
