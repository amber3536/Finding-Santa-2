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
    private bool holdingRock = false;
    private bool holdingAxe = false;
    public GameObject rock;
    private PickaxeRock currentGem;
    public PickUpRock pickUpRock;

    void Start()
    {
        int val = PlayerPrefs.GetInt("rock");
        if (val == 1)
        {
            animator.SetBool("Rock", true);
            holdingRock = true;
        }
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
            if (holdingRock)
            {
            dropRock();
            } 
            pickAxe.SetActive(false);
            animator.SetBool("Pickaxe", true);
            holdingAxe = true;
        } 
        else if (pickUpRock.rockReady)
        {
            if (holdingAxe)
            {
                dropAxe();
            }
            rock.SetActive(false);
            animator.SetBool("Rock", true);
            holdingRock = true;
        }

    }

    public void OnUseTool()
    {
        if (holdingAxe && currentGem != null && currentGem.gemReady)
        {
            currentGem.revealStone();
        }
    }

    public void OnDrop()
    {
        if (holdingRock)
        {
            dropRock();
        }
        else if (holdingAxe)
        {
            dropAxe();
        }
    }


    void dropRock()
    {
        rock.SetActive(true);
        rock.transform.position = new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0f);
        holdingRock = false;
        animator.SetBool("Rock", false);
    }

    void dropAxe()
    {
        animator.SetBool("Wood axe", false);
        pickAxe.SetActive(true);
        holdingAxe = false;
        Vector3 dropPosition = transform.position + Vector3.right;
        pickAxe.transform.position = dropPosition; //new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0f);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        PickaxeRock gem = other.GetComponent<PickaxeRock>();

        if (gem != null)
        {
            currentGem = gem;
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PickaxeRock gem = other.GetComponent<PickaxeRock>();       
    
        if (gem != null && gem == currentGem)
        {
            currentGem = null;
        }
    }
}
