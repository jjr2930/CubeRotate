using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text = null;

    int frame = 0;
    int fps = 0;
    private void Start()
    {
        StartCoroutine(IncreaseFPS());
        StartCoroutine(CountFPS());
        StartCoroutine(UpdateDebugText());
    }

    private IEnumerator UpdateDebugText()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            text.text = $"fps : {fps}\n created count : {CountClass.createdCount}";

        }
    }

    IEnumerator IncreaseFPS()
    {
        while(true)
        {
            frame++;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CountFPS()
    {
        float interval = 5f;
        while (true)
        {
            yield return new WaitForSeconds(interval);
            fps = frame / 5;
            frame = 0;
        }
    }
}
