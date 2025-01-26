using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
