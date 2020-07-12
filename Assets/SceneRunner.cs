using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneRunner : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    public void LoadScene()
    {
        SceneManager.LoadScene(this.GetComponent<Text>().text);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitMenu()
    {
        Application.Quit();
    }
}
