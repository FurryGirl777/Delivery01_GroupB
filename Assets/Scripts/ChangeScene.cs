using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gato"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
        
    
}
