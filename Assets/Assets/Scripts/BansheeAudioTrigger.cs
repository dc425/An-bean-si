
using UnityEngine;

public class BansheeAudioTrigger : MonoBehaviour
{
    private AudioSource bansheeAudio;

    public DangerWarningUI warningUI;

    [Header("Danger Settings")]
    public float dangerLevel = 0f;
    public float dangerIncreaseSpeed = 20f;
    public float dangerDecreaseSpeed = 15f;

    private bool playerInside = false;
    private bool warningTriggered = false;

    private void Awake()
    {
        bansheeAudio = GetComponent<AudioSource>();

        if (bansheeAudio != null)
        {
            bansheeAudio.loop = true;
            bansheeAudio.volume = 0f;
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            dangerLevel += dangerIncreaseSpeed * Time.deltaTime;
        }
        else
        {
            dangerLevel -= dangerDecreaseSpeed * Time.deltaTime;
        }

        dangerLevel = Mathf.Clamp(dangerLevel, 0f, 100f);

        // Control crying audio
        if (bansheeAudio != null)
        {
            bansheeAudio.volume = dangerLevel / 100f;

            if (dangerLevel > 0f && !bansheeAudio.isPlaying)
                bansheeAudio.Play();

            if (dangerLevel <= 0f && bansheeAudio.isPlaying)
                bansheeAudio.Stop();
        }

        // Trigger warning at maximum danger
        if (dangerLevel >= 100f && !warningTriggered)
        {
            warningTriggered = true;

            Debug.Log("SHOWING DANGER WARNING!");
            warningUI.ShowWarning();

            if (warningUI != null)
            {
                warningUI.ShowWarning();
            }

            Debug.Log("MAXIMUM DANGER!");
        }

        // Allow warning to trigger again after danger resets
        if (dangerLevel <= 0f)
        {
            warningTriggered = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") &&
            !other.transform.root.CompareTag("Player") &&
            !other.GetComponentInParent<CharacterController>())
            return;

        playerInside = true;

        Debug.Log("You are entering a dangerous area!");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player") &&
            !other.transform.root.CompareTag("Player") &&
            !other.GetComponentInParent<CharacterController>())
            return;

        playerInside = false;

        Debug.Log("You are leaving a dangerous area!");
    }
}
