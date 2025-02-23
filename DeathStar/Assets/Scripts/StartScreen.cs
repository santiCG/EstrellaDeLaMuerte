using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; 
    [SerializeField] private CanvasGroup startPanel;
    [SerializeField] private RawImage videoRawImage;
    private bool videoPlayed = false;

    void Start()
    {
        videoPlayer.Stop();
        SetVideoAlpha(0f);

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !videoPlayed)
            {
                Debug.Log("Touch detected");
                videoPlayer.Play();

                startPanel.DOFade(0f, 5.5f).OnComplete(() => startPanel.gameObject.SetActive(false));

                videoRawImage.DOFade(1f, 1f);
            }
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        videoRawImage.DOFade(0f, 0.5f);
        videoPlayed = true;
    }


    private void SetVideoAlpha(float alpha)
    {
        Color color = videoRawImage.color;
        color.a = alpha;
        videoRawImage.color = color;
    }
}
