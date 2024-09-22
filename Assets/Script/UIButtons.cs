using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIButtons : MonoBehaviour
{
    public RectTransform leafImage;         
    public CanvasGroup leafCanvasGroup;     
    public Button scaleButton, zoomButton, fadeButton, flipButton, shakeButton, slideButton;
    private Vector2 originalPosition;       
    private Vector3 originalScale;        

    void Start()
    {
        originalScale = leafImage.localScale;
        originalPosition = leafImage.anchoredPosition;

        scaleButton.onClick.AddListener(ScaleLeaf);
        zoomButton.onClick.AddListener(ZoomLeaf);
        fadeButton.onClick.AddListener(FadeLeaf);
        flipButton.onClick.AddListener(FlipLeaf);
        shakeButton.onClick.AddListener(ShakeLeaf);
        slideButton.onClick.AddListener(SlideLeaf);
    }

    void ScaleLeaf()
    {
        leafImage.DOScale(Vector3.one * 1.5f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            leafImage.DOScale(originalScale, 0.5f).SetEase(Ease.InOutBack);
        });
    }

    void ZoomLeaf()
    {
        leafImage.DOScale(new Vector3(2f, 2f, 2f), 0.3f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            leafImage.DOScale(originalScale, 0.3f).SetEase(Ease.OutExpo);
        });
    }

    void FadeLeaf()
    {
        leafCanvasGroup.DOFade(0f, 0.5f).OnComplete(() =>
        {
            leafCanvasGroup.DOFade(1f, 0.5f);
        });
    }

    void FlipLeaf()
    {
        leafImage.DORotate(new Vector3(0f, 180f, 0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            leafImage.DORotate(Vector3.zero, 0.5f).SetEase(Ease.OutExpo);
        });
    }

    void ShakeLeaf()
    {
        leafImage.DOShakePosition(0.5f, new Vector2(20f, 20f));
    }

    void SlideLeaf()
    {
        leafImage.DOAnchorPos(originalPosition + new Vector2(-50f, 0f), 0.5f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            leafImage.DOAnchorPos(originalPosition, 0.5f).SetEase(Ease.OutQuad);
        });
    }
}