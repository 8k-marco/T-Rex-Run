using UnityEngine;

public class Crouch : MonoBehaviour
{
    private Animator animator;
    private bool isCrouching = false;
    private CharacterController characterController;

    
    public float originalHeight;
    public float originalRadius;
    private Vector3 originalCenter;

   
    public float crouchHeight = 0.5f; 
    public float crouchRadius = 0.3f; 
    public Vector3 crouchCenter = new Vector3(0, 0.25f, 0); 

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

       
        originalHeight = characterController.height;
        originalRadius = characterController.radius;
        originalCenter = characterController.center;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (!isCrouching)
            {
                isCrouching = true;
                animator.SetBool("IsCrouching", isCrouching);

               
                characterController.height = crouchHeight;
                characterController.radius = crouchRadius;
                characterController.center = crouchCenter;
            }
        }
        else
        {
            if (isCrouching)
            {
                isCrouching = false;
                animator.SetBool("IsCrouching", isCrouching);

                
                characterController.height = originalHeight;
                characterController.radius = originalRadius;
                characterController.center = originalCenter;
            }
        }
    }
}

