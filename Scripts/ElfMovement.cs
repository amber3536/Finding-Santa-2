using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public ItemData itemBerries;
    Vector3 lastStepPos;
    public float lifetime = 6f;
    public float fadeTime = 2f;
    private RiverUnblock currentUnblock;
    private SnowyTree currentTree;
    private ThreeLogs currentLogs;
    private PickBerries currentBerries;
    public GameObject axe;
    public GameObject pickAxe;
    public PickUpAxe pickUpAxe;
    public GoInsideCabin goInsideCabin;
    private bool holdingAxe = false;
    private bool holdingLogs = false;
    private bool holdingBerries = false;
    private bool inventoryOpen = false;
    private int inventoryLocation = 0;
    public SaveMenu saveMenu;
    public OpenInventory openInventory;
    public PickUpFish pickUpFish;
    public GameObject fish;
    private PickaxeRock currentGem;
    public PickUpPickaxe pickUpPickaxe;


    void Start()

    {
        addCarryItem();
        lastStepPos = transform.position;
        rb = GetComponent<Rigidbody2D>(); // Get reference to the Rigidbody2D

    }

    public void addCarryItem()
    {
        if (SaveManager.Instance.carriedWorldObjectUniqueId == "rock")
        {
            animator.SetBool("Rock", true);
            holdingRock = true;
        }
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

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
        }
    }

    public void OnStoreinInventory()
    {
        Inventory inventory = GetComponent<Inventory>();

        if (currentLogs != null && currentLogs.logsReady)
        {
            inventory.AddItem(itemWood);
            currentLogs.threeLogs.SetActive(false);
        }
        else if (pickUpRock.rockReady)
        {
            inventory.AddItem(itemRock);
            rock.SetActive(false);
        }
        else if (currentBerries != null && currentBerries.pickReady)
        {
            inventory.AddItem(itemBerries);
            currentBerries.picking();
        }
    }

    public void OnPickUp()
    {
        if (!inventoryOpen)
        {
            if (pickUpRock.rockReady)
            {
                if (holdingBerries)
                {
                    dropBerries();
                }
                else if (holdingAxe)
                {
                    dropAxe();
                }
                else if (holdingLogs)
                {
                    dropLogs();
                }
                rock.SetActive(false);
                animator.SetBool("Rock", true);
                holdingRock = true;
                SaveManager.Instance.carriedWorldObjectUniqueId = "rock";
                pickUpRock.destroyRock();
            }
            else if (pickUpAxe.axeReady)
            {
                if (holdingRock)
                {
                    dropRock();
                }
                else if (holdingAxe)
                {
                    dropAxe();
                }
                else if (holdingLogs)
                {
                    dropLogs();
                }
                axe.SetActive(false);
                animator.SetBool("Wood axe", true);
                holdingAxe = true;
            }

            else if (currentLogs != null && currentLogs.logsReady)
            {
                if (holdingAxe)
                {
                    dropAxe();
                }
                else if (holdingRock)
                {
                    dropRock();
                }
                else if (holdingBerries)
                {
                    dropBerries();
                }
                animator.SetBool("Logs", true);
                Destroy(currentLogs.threeLogs);
                holdingLogs = true;
            }
            else if (currentBerries != null && currentBerries.pickReady)
            {
                if (holdingBerries)
                {
                    Inventory inventory = GetComponent<Inventory>();
                    inventory.AddItem(itemBerries);
                    //currentBerries.picking();
                }
                else if (holdingRock)
                {
                    dropRock();
                }
                else if (holdingAxe)
                {
                    dropAxe();
                }
                else if (holdingLogs)
                {
                    dropLogs();
                }


                holdingBerries = true;
                currentBerries.picking();
                animator.SetBool("Berries", true);
            }
            else if (pickUpPickaxe.pickAxeReady)
            {
                if (holdingRock)
                {
                    dropRock();
                } 
                pickAxe.SetActive(false);
                animator.SetBool("Pickaxe", true);
                holdingAxe = true;
            } 
            else if (pickUpFish.fishReady)
            {
                if (holdingAxe)
                {
                    dropAxe();
                }
                else if (holdingRock)
                {
                    dropRock();
                }
                fish.SetActive(false);
                animator.SetBool("Fish", true);
            }

        }
        else
        {
            Inventory inventory = GetComponent<Inventory>();
            string curr = inventory.IdentifyItem(inventoryLocation);
            Debug.Log("inventory item "+ curr);
            inventory.RemoveItem(inventoryLocation);
            inventoryLocation = 0;
            // put item in hand, close inventory

            

        }

    }

    public void OnDrop()
    {
        // if goInsideCabin.relocate and item is berries, increment (inside and outside inventory)

        if (holdingRock)
        {
            dropRock();
        }
        else if (holdingAxe)
        {
            dropAxe();
        }
        else if (inventoryOpen)
        {
            Inventory inventory = GetComponent<Inventory>();
            string curr = inventory.IdentifyItem(inventoryLocation);
            Debug.Log("inventory item "+ curr);
        
            ItemData item = inventory.GetItem(inventoryLocation);
            DropItem(item);

            inventory.RemoveItem(inventoryLocation);
            inventoryLocation = 0;
        }
        else if (holdingLogs)
        {
            if (currentUnblock != null)
            {
                animator.SetBool("Logs", false);
                currentUnblock.UnblockRiver();
            }
            else
            {
                Vector3 dropPosition = transform.position + Vector3.right;

                Instantiate(itemWood.worldPrefab, dropPosition, Quaternion.identity);
                animator.SetBool("Logs", false);
                holdingLogs = false;
            }

        }
        
        
    }

    public void DropItem(ItemData item)
    {
        if (item.worldPrefab != null)
        {
            Vector3 dropPosition = transform.position + Vector3.right;

            Instantiate(item.worldPrefab, dropPosition, Quaternion.identity);
        }
    }

    public void OnOpenInventory()
    {
        inventoryOpen = !inventoryOpen;
        inventoryLocation = 0;
        //Debug.Log("yowza");
        openInventory.openingInventory();
    }

    public void OnSaveMenu()
    {
        saveMenu.ToggleSaveMenu();
    }

    void dropRock()
    {
        rock.SetActive(true);
        Vector3 dropPosition = transform.position + Vector3.right;
        rock.transform.position = dropPosition; // (transform.position.x + .5f, transform.position.y - .5f, 0f);
        holdingRock = false;
        animator.SetBool("Rock", false);
        SaveManager.Instance.carriedWorldObjectUniqueId = null;
        pickUpRock.restoreRock();
    }

    void dropLogs()
    {
        DropItem(itemWood);
        animator.SetBool("Logs", false);
        holdingLogs = false;
    }

    void dropAxe()
    {
        animator.SetBool("Wood axe", false);
        axe.SetActive(true);
        holdingAxe = false;
        Vector3 dropPosition = transform.position + Vector3.right;
        axe.transform.position = dropPosition; //new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0f);
    }

    void dropBerries()
    {
        DropItem(itemBerries);
        animator.SetBool("Berries", false);
        holdingBerries = false;
    }

    public void OnUseTool()
    {
        if (holdingAxe && currentTree != null)
        {
            animator.SetBool("Axing", true);
            Invoke("stopAxing", 2f);
        }
        else if (currentGem != null && currentGem.gemReady)
        {
            currentGem.revealStone();
        }

    }

    void stopAxing()
    {
        animator.SetBool("Axing", false);
        currentTree.chopTree();
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

        rb.linearVelocity = moveInput * speed;


        //snow prints
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Forest Intro")
        {
            if (Vector3.Distance(transform.position, lastStepPos) > stepDistance)
            {
                Vector3 movement = transform.position - lastStepPos;
                Vector3 moveDirection = movement.normalized;
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(0, 0, angle - 90f);
                GameObject newClone = Instantiate(footprintPrefab, transform.position, rot);
                SpriteRenderer sr = newClone.GetComponent<SpriteRenderer>();
                StartCoroutine(FadeFootprint(sr, newClone));
                destroyClone(newClone);
                lastStepPos = transform.position;
                FeetCrunching();
            }
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
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
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
        PickaxeRock gem = other.GetComponent<PickaxeRock>();

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
        }
        else if (gem != null)
        {
            currentGem = gem;
        }  


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        RiverUnblock block = other.GetComponent<RiverUnblock>();
        SnowyTree tree = other.GetComponent<SnowyTree>();
        ThreeLogs logs = other.GetComponent<ThreeLogs>();
        PickBerries berries = other.GetComponent<PickBerries>();
        PickaxeRock gem = other.GetComponent<PickaxeRock>();

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
        else if (gem != null && gem == currentGem)
        {
            currentGem = null;
        }
    }

}
