using UnityEngine;

public class ObjectVisibilityToggle : MonoBehaviour
{
    public GameObject objectToToggle;
    public float toggleDistance = 3f;
    private bool objectVisible = false;

    private void Start()
    {
        objectToToggle.SetActive(false); // Set object initially invisible
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleObjectVisibility();
        }
    }

    private void ToggleObjectVisibility()
    {
        if (!objectVisible)
        {
            Vector3 playerPosition = transform.position;
            Vector3 objectPosition = objectToToggle.transform.position;
            float distance = Vector3.Distance(playerPosition, objectPosition);

            if (distance <= toggleDistance)
            {
                objectVisible = true;
                objectToToggle.SetActive(true); // Set object visible
            }
        }
    }
}

