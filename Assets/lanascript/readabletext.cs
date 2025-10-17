using UnityEngine;

public class ReadableText : MonoBehaviour, IInteractable
{
    [Header("Object Info")]
    public string objectName = "Readable Object";

    [TextArea]
    public string textToDisplay = "This is a piece of text that shows when you interact.";

    [Header("Text Display Components")]
    public GameObject textContainer; // GameObject to enable/disable (e.g. panel or text mesh)
    public TextMesh textMesh;        // Text component to set the content

    private bool isTextVisible = false;

    void Start()
    {
        // Hide the text at the beginning
        if (textContainer != null)
            textContainer.SetActive(false);

        // Set initial text content
        if (textMesh != null)
            textMesh.text = textToDisplay;
    }

    public void OnLookAt()
    {
        Debug.Log("Looking at: " + objectName);
    }

    public void OnInteract()
    {
        Debug.Log("Interacting with: " + objectName);

        if (textContainer != null)
        {
            isTextVisible = !isTextVisible;
            textContainer.SetActive(isTextVisible);
        }
    }

    public void OnDisengage()
    {
        Debug.Log("Disengaged from: " + objectName);

        if (textContainer != null)
        {
            isTextVisible = false;
            textContainer.SetActive(false);
        }
    }
}
