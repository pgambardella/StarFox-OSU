using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HitTime : MonoBehaviour, IPointerDownHandler
{
    public CanvasGroup circlesCanvas;
    public Image ringCircle;
    public TMP_Text numberText;
    public TMP_Text scoreText;
    public CanvasGroup scoreCanvas;
    public float initialDelay = 2.0f;
    public float timeToPress = 2.0f;
    public float targetScale = 0.25f;

    private bool canReceiveTap;

    void Start()
    {
        MusicGameManager.Instance.SetupHit(this);
        canReceiveTap = false;
        scoreCanvas.alpha = 0;
        circlesCanvas.DOFade(0, 1.0f).From()
            .SetDelay(initialDelay)
            .OnStart(() => 
            {   
                canReceiveTap = true;
            });
        ringCircle.rectTransform.DOScale(targetScale, timeToPress)
            .SetDelay(initialDelay)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                canReceiveTap = false;
                circlesCanvas.DOFade(0, 0.1f);
                circlesCanvas.transform.DOScale(0, 0.1f);
            });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!canReceiveTap) { return; }

        //Debug.Log("OnPointerDown, localScale " + ringCircle.rectTransform.localScale);

        float currentScale = ringCircle.rectTransform.localScale.x;
        float currentGoalPos = Remap(currentScale, 1, targetScale, 0, 1);

        float score = MusicGameManager.Instance.CalculateScore(currentGoalPos);
        MusicGameManager.Instance.IncreaseScore(score);

        scoreText.text = score.ToString();

        circlesCanvas.DOFade(0, 0.3f);

        if (score > 10)
        { 
            Sequence s = DOTween.Sequence();
            s.Append(scoreCanvas.DOFade(1, 0.6f));
            s.Join(scoreText.transform.DOLocalMoveY(60.0f, 0.5f));
            s.Join(scoreText.transform.DOPunchScale(Vector3.one * 0.5f, 0.5f, vibrato: 4, elasticity: 2));
            s.AppendInterval(.2f);
            s.Append(scoreCanvas.DOFade(0, 0.2f));
        }

        canReceiveTap = false;
    }

    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
