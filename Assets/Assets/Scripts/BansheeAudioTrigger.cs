using UnityEngine;

public class BansheeAudioTrigger : MonoBehaviour
{
    private AudioSource bansheeAudio;
    private bool hasPlayed = false;

    private void Awake()
    {
        bansheeAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed)
            return;

        // Works with a tagged player or an untagged FPS controller.
        if (!other.CompareTag("Player") &&
            !other.transform.root.CompareTag("Player") &&
            !other.GetComponentInParent<CharacterController>())
            return;

        if (bansheeAudio != null && bansheeAudio.clip != null)
        {
            bansheeAudio.Play();
            Debug.Log("You are leaving a safe zone");
            hasPlayed = true;
        }
        else
        {
            Debug.LogWarning("Banshee AudioSource or Audio Clip is missing!");
        }
    }
}
