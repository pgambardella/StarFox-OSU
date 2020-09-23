using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicGameManager : Singleton<MusicGameManager>
{
    public TMP_Text globalScore;

    public float timeScaleA = 0.9f;
    public float timeScaleB = 0.75f;
    public float timeScaleC = 0.5f;

    public float pointsA = 100;
    public float pointsB = 80;
    public float pointsC = 10;
    public float pointsD = 0;

    private float totalScore;
    private float currentHitTime;

    void Start()
    {
        totalScore = 0;
        currentHitTime = 0;
        UpdateUIScore(false);
    }

    public void SetupHit(HitTime hitTime)
    {
        hitTime.numberText.text = (++currentHitTime).ToString();
    }

    public float CalculateScore(float currentGoalPos)
    {
        float score = 0;
        if (currentGoalPos >= timeScaleA)
        {
            score = pointsA;
        }
        else if (currentGoalPos >= timeScaleB)
        {
            score = pointsB;
        }
        else if (currentGoalPos >= timeScaleC)
        {
            score = pointsC;
        }

        //Debug.Log("score " + score);

        return score;
    }

    public void IncreaseScore(float score)
    {
        if (score <= 0) { return; }

        totalScore += score;
        UpdateUIScore(true);
    }

    private void UpdateUIScore(bool punch)
    {
        globalScore.text = string.Format("Score: {0}", (int)totalScore);
        if (punch)
        {
            globalScore.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f);
        }
    }
}
