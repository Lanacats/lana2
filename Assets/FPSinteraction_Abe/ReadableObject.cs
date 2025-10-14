using UnityEngine;

public class ReadableObject : MonoBehaviour, IInteractable
{
    public string objectName = "A mysterious book"; // Name shown in logs (can customize per object)

    public AudioSource audioS; // Primary AudioSource
    public AudioSource audioC; // Secondary AudioSource

    // Triggered when the player looks at the object
    public void OnLookAt()
    {
        Debug.Log("Looking at: " + objectName);
    }

    // Triggered when the player presses the interact button while looking at the object
    public void OnInteract()
    {
        Debug.Log("Interacting with: " + objectName);

        // Assign audioS if not already assigned
        if (audioS == null)
        {
            audioS = GetComponent<AudioSource>();
        }

        // Play from audioS if valid
        if (audioS != null && audioS.clip != null)
        {
            audioS.PlayOneShot(audioS.clip);
        }
        else
        {
            Debug.LogWarning("audioS or its clip is missing!");
        }

        // Play from audioC if assigned and valid
        if (audioC != null && audioC.clip != null)
        {
            audioC.PlayOneShot(audioC.clip);
        }
        else
        {
            Debug.LogWarning("audioC or its clip is missing!");
        }
    }

    // Triggered when the player stops looking at the object
    public void OnDisengage()
    {
        Debug.Log("Disengage: " + objectName);
    }
}
