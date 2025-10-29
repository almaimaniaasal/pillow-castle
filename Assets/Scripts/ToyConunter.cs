using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ToyCounterUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI counterText; 

    [Header("Animation")]
    public float animateDuration = 0.6f;
    public string prefix = "Toys: ";
    public string suffix = "5"; 

    int displayedCount = 0;

    void Start()
    {
      
        SetImmediate(0);
    }

    public void SetImmediate(int value)
    {
        displayedCount = value;
        counterText.text = prefix + displayedCount + suffix;
    }

    public void UpdateCount(int newCount)
    {
        StopAllCoroutines();
        StartCoroutine(AnimateCount(displayedCount, newCount));
    }

    IEnumerator AnimateCount(int from, int to)
    {
        float t = 0f;
        while (t < animateDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / animateDuration);
            int current = Mathf.RoundToInt(Mathf.Lerp(from, to, normalized));
            counterText.text = prefix + current + suffix;
            yield return null;
        }
        displayedCount = to;
        counterText.text = prefix + to + suffix;
    }
}