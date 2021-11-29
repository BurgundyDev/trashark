using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    GameObject[] fish;
    public GameObject trashark;
    public GameObject trasharkHealth;
    public float timeLeft;
    private void Start()
    {
        timeLeft = 120.0f;
        fish = GameObject.FindGameObjectsWithTag("Fish");
    }

    public void AddToTime()
    {
        timeLeft += 10.0f;
    }

    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = timeLeft.ToString("0");
        }
        else
        {
            trashark.SetActive(true);
            trasharkHealth.SetActive(true);
            foreach(GameObject element in fish)
            {
                element.SetActive(false);
            }
        }
    }
}
