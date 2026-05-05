using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ElfMovementCave : MonoBehaviour
{
   public float speed = 5f; // Movement speed
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isFacingRight = true;
    //public GameObject footprintPrefab;
    //public float stepDistance = 0.3f;
    //public AudioSource crunching;
    //public AudioClip crunch;

    //Vector3 lastStepPos;
    //bool leftFoot = true;
    //float footSpacing = 0.3f;
    //public float lifetime = 6f;
    //public float fadeTime = 2f;
    //public SpriteRenderer sr;
    //private List<GameObject> clonesList = new List<GameObject>();

    // bool leftFoot = true;
    // float stepDistance = 0.5f;
    // float footSpacing = 0.2f;
    // Vector3 lastFramePos;
    // Vector3 lastStepPos;

    // Vector3 lastPos;
    // float distanceTravelled = 0f;


    void Start()

    {
        // lastFramePos = transform.position;
        //lastStepPos = transform.position;
        rb = GetComponent<Rigidbody2D>(); // Get reference to the Rigidbody2D

    }

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     moveInput = context.ReadValue<Vector2>();
    // }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log("Move input: " + moveInput);
        // Your movement code
    }

    void Update()

    {
        //animator.setFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        // moveInput.x = Input.GetAxis("Horizontal"); // Get left/right input
        // moveInput.y = Input.GetAxis("Vertical");

        // moveInput.Normalize();

        if (moveInput.x > 0 && !isFacingRight) {
            Flip();
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            Flip();
        }
        else if (moveInput.y > 0) {
            animator.SetBool("Walk away", true);
        }
        else if (moveInput.y < 0) {
            animator.SetBool("Walk towards", true);
        }
        else {
            animator.SetBool("Walk away", false);
            animator.SetBool("Walk towards", false);
        }

        // Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        // transform.Translate(move * speed * Time.deltaTime);
        rb.linearVelocity = moveInput * speed;

        // if (Vector3.Distance(transform.position, lastStepPos) > stepDistance)
        // {
        //     Vector3 movement = transform.position - lastStepPos;
        //     Vector3 moveDirection = movement.normalized;
        //     float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //     Quaternion rot = Quaternion.Euler(0, 0, angle - 90f);
        //     //Quaternion rot = Quaternion.LookRotation(Vector3.forward, moveInput);
        //     //GameObject newClone = Instantiate(footprintPrefab, transform.position, rot);
        //     //SpriteRenderer sr = newClone.GetComponent<SpriteRenderer>();
        //     //StartCoroutine(FadeFootprint(sr, newClone));
        //     // Instantiate(footprintPrefab, transform.position, Quaternion.identity);
        //     //destroyClone(newClone);
        //     lastStepPos = transform.position;
        //     //FeetCrunching();
        //     //Debug.Log(transform.position);
        // }
  
    }

    // void destroyClone(GameObject newClone)
    // {   
    //     Destroy(newClone, 5f);  
    // }

    // void FeetCrunching()
    // {
    //     if (!crunching.isPlaying)
    //     {
    //         crunching.PlayOneShot(crunch);
    //     }
    // }

    void Flip() 
    {
        //if (!dontMove) {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        //}  
    }
}
