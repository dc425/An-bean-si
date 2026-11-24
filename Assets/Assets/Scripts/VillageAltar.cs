
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VillageAltar : MonoBehaviour
{
    public int requiredGold = 10;
    public int depositedGold = 0;

    public TMP_Text interactionText;
    public TMP_Text progressText;

    private PlayerGold playerGold;
    private bool playerNearby = false;
    private bool completed = false;

    void Start()
    {
        UpdateProgress();

        if (interactionText != null)
            interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame && !completed)
        {
            DepositGold();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerGold = other.GetComponent<PlayerGold>();
            playerNearby = playerGold != null;

            if (interactionText != null && playerNearby && !completed)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press E to deposit gold";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            playerGold = null;

            if (interactionText != null)
                interactionText.gameObject.SetActive(false);
        }
    }

    void DepositGold()
    {
        int amount = playerGold.DepositAllGold();

        depositedGold += amount;

        if (depositedGold >= requiredGold)
        {
            depositedGold = requiredGold;
            completed = true;
            Debug.Log("Final structure unlocked!");
            
            if (interactionText != null)
                interactionText.text = "Construction complete!";
        }
        else
        {
            Debug.Log("Deposited " + amount + " gold.");
        }

        UpdateProgress();
    }

    void UpdateProgress()
    {
        if (progressText != null)
        {
            progressText.text = "Altar: " + depositedGold + " / " + requiredGold;
        }
    }
}
