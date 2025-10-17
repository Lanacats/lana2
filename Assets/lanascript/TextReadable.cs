using UnityEngine;
using TMPro;
using System.Collections;

public class TextReadableObject : MonoBehaviour, IInteractable
{
    public string objectName = "A mysterious book";  // Name shown in logs
    [TextArea]
    public string readableText;                      // Text to show on interaction

    public GameObject textPanel;                     // UI container (e.g., panel)
    public TextMeshProUGUI textDisplay;              // UI text field
    public float hideDelay = 5f;                     // Time before auto-hide (seconds)

    private Coroutine hideCoroutine;

    public void OnLookAt()
    {
        Debug.Log("Looking at: " + objectName);
    }

    public void OnInteract()
    {
        Debug.Log("Interacting with: " + objectName);

        if (textDisplay != null && textPanel != null)
        {
            textPanel.SetActive(true);
            textDisplay.text = readableText;

            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
            }
            hideCoroutine = StartCoroutine(HideTextAfterDelay());
        }
    }

    public void OnDisengage()
    {
        Debug.Log("Disengage: " + objectName);

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        if (textPanel != null)
        {
            textPanel.SetActive(false);
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);

        if (textPanel != null)
        {
            textPanel.SetActive(false);
        }

        hideCoroutine = null;
    }
}
