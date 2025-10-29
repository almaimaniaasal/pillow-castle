using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(remainingTime/ 60);
        int sec = Mathf.FloorToInt(remainingTime%60);

        timerText.text =string.Format("{0:00}:{1:00}",min,sec);



    }
}
