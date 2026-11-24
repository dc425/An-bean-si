
using UnityEngine;

public class DangerManager : MonoBehaviour
{
    public AudioSource cryingAudio;

    public float dangerLevel = 0f;
    public float dangerIncreaseSpeed = 20f;
    public float dangerDecreaseSpeed = 30f;

    private bool playerInside = false;

    void Update()
    {
        // Increase danger inside the zone
        if (playerInside)
        {
            dangerLevel += dangerIncreaseSpeed * Time.deltaTime;
        }
        else
        {
            dangerLevel -= dangerDecreaseSpeed * Time.deltaTime;
        }

        // Keep danger between 0 and 100
        dangerLevel = Mathf.Clamp(dangerLevel, 0f, 100f);

        // Adjust crying volume
        cryingAudio.volume = dangerLevel / 100f;

        // Start and stop crying
        if (dangerLevel > 0 && !cryingAudio.isPlaying)
        {
            cryingAudio.Play();
        }
        else if (dangerLevel <= 0 && cryingAudio.isPlaying)
        {
            cryingAudio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
