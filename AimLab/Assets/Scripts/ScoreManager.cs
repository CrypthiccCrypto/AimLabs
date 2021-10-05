using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    void Start() {
        scoreText = GetComponent<Text>();
    }
    void Update(){
        scoreText.text = "Score: " + score;
    }
    public void incrementScore() {
        score += 10;
    }
}
