using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class StartMenuController : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Exit();
        }
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}
