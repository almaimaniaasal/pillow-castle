using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [Header("Game Over Settings")]
    public GameObject gameOverPanel; 
    public Build itemsTotal; 
    public int requiredScore = 20;

    void Update()
    {
        if (remainingTime > 0) { 
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)      
        {
            remainingTime = 0;
            timerText.color = Color.red;

            if (itemsTotal.ItemCount < requiredScore)
            {
                ShowGameOver();
            }
        }
        
        


        int min = Mathf.FloorToInt(remainingTime/ 60);
        int sec = Mathf.FloorToInt(remainingTime%60);

        timerText.text =string.Format("{0:00}:{1:00}",min,sec);



    }
    void ShowGameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true); 
    }
}
