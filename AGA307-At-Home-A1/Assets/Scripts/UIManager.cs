using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text targetText;

    private void Start()
    {
        UpdateScore(0);
        UpdateTime(0);
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateTime(int _time)
    {
        timerText.text = _time.ToString("F2");
    }

    public void UpdateTargetCount(int _count)
    {
        targetText.text = "Enemies: " + _count.ToString();
    }

}
