using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickPlay : MonoBehaviour
{
    public void changeScene() {
        string sceneName = "Main Scene";
        SceneManager.LoadScene(sceneName);    
    }
}
