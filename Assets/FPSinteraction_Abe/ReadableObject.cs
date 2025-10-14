using UnityEngine;

public class ReadableObject : MonoBehaviour, IInteractable
{
    public string objectName = "A mysterious book"; // Name shown in logs (can customize per object)

    public AudioSource audioS; // Speaker 
    public AudioClip audioC; // Sound

    // Triggered when the player looks at the object
    public void OnLookAt()
    {
        Debug.Log("Looking at: " + objectName);
    }

    // Triggered when the player presses the interact button while looking at the object
    public void OnInteract()
    {
        Debug.Log("Interacting with: " + objectName);

        // Play from audioS if valid
        if (audioS && audioC)
        {
            audioS.PlayOneShot(audioC, 1f);
        }
    }

    // Triggered when the player stops looking at the object
    public void OnDisengage()
    {
        Debug.Log("Disengage: " + objectName);
    }
}
