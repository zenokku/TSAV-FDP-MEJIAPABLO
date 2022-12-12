using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform camera;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, camera.eulerAngles.y, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        controller.Move(move * Time.deltaTime * playerSpeed);

        move = Vector3.ClampMagnitude(move, 1);
        float magnitude = move.magnitude;
        animator.SetFloat("Magnitude", magnitude);
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", z);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
