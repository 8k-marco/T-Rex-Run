using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    private bool isCrouching = false;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;
    public float standingHeight = 2f;   

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        direction = Vector3.zero;
    }

    private void Update()
    {
        UpdateMovement();

        if (Input.GetButtonDown("Fire1"))
        {
            ToggleCrouch();
        }
    }

    private void UpdateMovement()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                GetComponent<Animator>().Play("Sprung");
                direction = Vector3.up * jumpForce;
            }

        }

        character.Move(direction * Time.deltaTime);
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")){
            GameManager.Instance.GameOver();
        }
    }
}
