using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickPlay : MonoBehaviour
{
    string sceneName;

    void Start() {
        sceneName = "Main Scene";
    }
    public void changeScene() {
        SceneManager.LoadScene(sceneName);    
    }
}
