using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        score = 0;
    }

    
    public void AddToScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
