using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ElfMovementMine : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isFacingRight = true;
    public GameObject pickAxe;
    public PickUpPickaxe pickUpPickaxe;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get reference to the Rigidbody2D
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }

    public void OnPickUp()
    {
        if (pickUpPickaxe.pickAxeReady)
        {
            pickAxe.SetActive(false);
            animator.SetBool("Pickaxe", true);
        }   
    }

    void Update()

    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));

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
            //Debug.Log("towards");
            animator.SetBool("Walk towards", true);
        }
        else {
            animator.SetBool("Walk away", false);
            animator.SetBool("Walk towards", false);
        }

        // Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        // transform.Translate(move * speed * Time.deltaTime);
        rb.linearVelocity = moveInput * speed;


  
    }



    void Flip() 
    {
        //if (!dontMove) {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        //}  
    }
}
