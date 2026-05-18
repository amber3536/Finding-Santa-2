using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ElfMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isFacingRight = true;
    public GameObject footprintPrefab;
    public float stepDistance = 0.3f;
    public AudioSource crunching;
    public AudioClip crunch;
    public GameObject rock;
    public bool holdingRock = false;
    public PickUpRock pickUpRock;
    public ItemData itemWood;
    public ItemData itemRock;
    Vector3 lastStepPos;
    public float lifetime = 6f;
    public float fadeTime = 2f;
    private RiverUnblock currentUnblock;
    private SnowyTree currentTree;
    private ThreeLogs currentLogs;
    private PickBerries currentBerries;
    public GameObject axe;
    public PickUpAxe pickUpAxe;
    private bool holdingAxe = false;
    private bool holdingLogs = false;
    private bool inventoryOpen = false;
    private int inventoryLocation = 0;

    public OpenInventory openInventory;
    //public InventoryUI inventoryUI;


    void Start()

    {
        lastStepPos = transform.position;
        rb = GetComponent<Rigidbody2D>(); // Get reference to the Rigidbody2D

    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log("Move input: " + moveInput);

        if (inventoryOpen)
        {
            
            if (moveInput.x == 1)
            {
                inventoryLocation++;
            }
            else if (moveInput.x == -1)
            {
                inventoryLocation--;
            }
            //Debug.Log("loc "+ inventoryLocation);
        }
        
        // Your movement code
    }

    public void OnStoreinInventory()
    {
        //Debug.Log("it worked!");
        Inventory inventory = GetComponent<Inventory>();

        if (currentLogs != null && currentLogs.logsReady)
        //if (inventory != null)
        {
            inventory.AddItem(itemWood);
            currentLogs.threeLogs.SetActive(false);
            
            //Destroy(gameObject);
        }
        else if (pickUpRock.rockReady)
        {
            inventory.AddItem(itemRock);
            rock.SetActive(false);
        }
    }

    public void OnPickUp()
    {
        if (!inventoryOpen)
        {
            if (pickUpRock.rockReady)
            {
                rock.SetActive(false);
                animator.SetBool("Rock", true);
                holdingRock = true;
            }
            else if (pickUpAxe.axeReady)
            {
                if (holdingRock)
                {
                    dropRock();
                }
                axe.SetActive(false);
                animator.SetBool("Wood axe", true);
                holdingAxe = true;
            }
            else if (holdingLogs && currentUnblock != null)
            {
                animator.SetBool("Logs", false);
                currentUnblock.UnblockRiver();
            }

            else if (currentLogs != null && currentLogs.logsReady)
            {
                if (holdingAxe)
                {
                    dropAxe();
                }
                animator.SetBool("Logs", true);
                currentLogs.threeLogs.SetActive(false);
                holdingLogs = true;
            }
            else if (currentBerries != null && currentBerries.pickReady)
            {
                currentBerries.picking();
            }
            else if (holdingRock)
            {
                dropRock();
            }
            else if (holdingAxe)
            {
                dropAxe();
            }
        }
        else
        {
            Inventory inventory = GetComponent<Inventory>();
            Debug.Log("inventory loc "+ inventoryLocation);
            inventory.RemoveItem(inventoryLocation);
        }

    }

    public void OnOpenInventory()
    {
        inventoryOpen = !inventoryOpen;
        inventoryLocation = 0;
        //Debug.Log("yowza");
        openInventory.openingInventory();
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
        axe.SetActive(true);
        holdingAxe = false;
        axe.transform.position = new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0f);
    }

    public void OnUseTool()
    {
        if (holdingAxe && currentTree != null)
        {
            animator.SetBool("Axing", true);
            Invoke("stopAxing", 2f);
        }


    }

    void stopAxing()
    {
        animator.SetBool("Axing", false);
        currentTree.chopTree();
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

        if (Vector3.Distance(transform.position, lastStepPos) > stepDistance)
        {
            Vector3 movement = transform.position - lastStepPos;
            Vector3 moveDirection = movement.normalized;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, 0, angle - 90f);
            //Quaternion rot = Quaternion.LookRotation(Vector3.forward, moveInput);
            GameObject newClone = Instantiate(footprintPrefab, transform.position, rot);
            SpriteRenderer sr = newClone.GetComponent<SpriteRenderer>();
            StartCoroutine(FadeFootprint(sr, newClone));
            // Instantiate(footprintPrefab, transform.position, Quaternion.identity);
            destroyClone(newClone);
            lastStepPos = transform.position;
            FeetCrunching();
            //Debug.Log(transform.position);
        }
  
    }


    void destroyClone(GameObject newClone)
    {   
        Destroy(newClone, 5f);  
    }

    void FeetCrunching()
    {
        if (!crunching.isPlaying)
        {
            crunching.PlayOneShot(crunch);
        }
    }

    void Flip() 
    {
        //if (!dontMove) {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        //}  
    }

    IEnumerator FadeFootprint(SpriteRenderer sr, GameObject obj)
    {
        float duration = 3f;
        float t = 0;

        Color c = sr.color;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / duration);
            sr.color = c;
            yield return null;
        }

        Destroy(obj);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RiverUnblock block = other.GetComponent<RiverUnblock>();
        SnowyTree tree = other.GetComponent<SnowyTree>();
        ThreeLogs logs = other.GetComponent<ThreeLogs>();
        PickBerries berries = other.GetComponent<PickBerries>();

        if (block != null)
        {
            Debug.Log("i am here");
            currentUnblock = block;
        }
        else if (tree != null)
        {
            currentTree = tree;
        }
        else if (logs != null)
        {
            currentLogs = logs;
        }
        else if (berries != null)
        {
            currentBerries = berries;
            //Debug.Log("pppppft");
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        RiverUnblock block = other.GetComponent<RiverUnblock>();
        SnowyTree tree = other.GetComponent<SnowyTree>();
        ThreeLogs logs = other.GetComponent<ThreeLogs>();
        PickBerries berries = other.GetComponent<PickBerries>();

        if (block != null && block == currentUnblock)
        {
            currentUnblock = null;
        }
        else if (tree != null && tree == currentTree)
        {
            currentTree = null;
        }
        else if (logs != null && logs == currentLogs)
        {
            currentLogs = null;
        }
        else if (berries != null && berries == currentBerries)
        {
            currentBerries = null;
        }
    }

}
