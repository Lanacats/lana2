using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Tooltip("Name of the scene to load.")]
    public string nextSceneName;

    [Tooltip("Optional delay before loading the scene (in seconds).")]
    public float delay = 0f;

    // Call this method to trigger the scene transition
    public void LoadNextScene()
    {
        if (delay > 0f)
        {
            Invoke(nameof(DoSceneLoad), delay);
        }
        else
        {
            DoSceneLoad();
        }
    }

    private void DoSceneLoad()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("SceneTransition: Next scene name is not set.");
        }
    }
}