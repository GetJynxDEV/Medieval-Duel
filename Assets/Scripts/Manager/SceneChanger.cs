using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneMainMenu()
    {
        //Scene index 0 is the main menu scene
        SceneManager.LoadSceneAsync(0);
    }

    public void SceneGame()
    {
        //Scene index 1 is the game scene
        SceneManager.LoadSceneAsync(1);
    }
}
