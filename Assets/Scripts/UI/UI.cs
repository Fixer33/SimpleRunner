using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private CanvasGroup FinishPanelGroup;
    [Header("Coin count")]
    [SerializeField] private TMP_Text CoinCountText;
    [SerializeField] private GameObject CoinCountIcon;
    [Header("Restart counter")]
    [SerializeField] private TMP_Text RestartCount;

    private void Start()
    {
        Events.PlayerFinished.AddListener(OnPlayerFinish);
        Events.CoinPicked.AddListener(OnCoinPick);

        CoinCountText.text = GameDataHandler.Instance.Data.CoinCount.ToString();
        RestartCount.text = GameDataHandler.Instance.Data.RestartCount.ToString();
    }
    private void OnDestroy()
    {
        Events.PlayerFinished.RemoveListener(OnPlayerFinish);
        Events.CoinPicked.RemoveListener(OnCoinPick);
    }

    public void Restart()
    {
        GameDataHandler.Instance.Data.RestartCount++;
        SceneManager.LoadScene(0);
    }

    private void OnPlayerFinish()
    {
        StartCoroutine(FinishPanelAppear(3));
    }
    private IEnumerator FinishPanelAppear(float time)
    {
        var finishPanelObject = FinishPanelGroup.gameObject;
        finishPanelObject.transform.DOScale(0, 0.01f);
        finishPanelObject.transform.DOScale(1, time);

        const float interval = 0.1f;
        int iterations = Mathf.FloorToInt(time / interval);
        float step = 1f / iterations;
        for (int i = 0; i < iterations; i++)
        {
            FinishPanelGroup.alpha += step;
            yield return new WaitForSecondsRealtime(interval);
        }
        FinishPanelGroup.alpha = 1;
    }
    private void OnCoinPick()
    {
        CoinCountText.text = GameDataHandler.Instance.Data.CoinCount.ToString();
        DOTween.Sequence().Append(CoinCountIcon.transform.DOScale(2, 0.25f)).Append(CoinCountIcon.transform.DOScale(1, 0.25f));
    }
}
