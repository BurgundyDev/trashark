using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    private void Start()
    {
        timeLeft = 120.0f;
    }

    public void AddToTime()
    {
        timeLeft += 10.0f;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = timeLeft.ToString("0");
    }
}
