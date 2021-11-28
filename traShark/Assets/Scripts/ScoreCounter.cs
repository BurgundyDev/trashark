using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score;

    public void AddToScore()
    {
        score += 1;
    }

    private void Update()
    {
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Saved fish: " + score.ToString();
    }
}
