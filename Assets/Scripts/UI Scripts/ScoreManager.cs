using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        int score = GameObject.Find("Player").GetComponent<PlayerController>().money;
        scoreText.text = score.ToString() + "$";
    }
}
