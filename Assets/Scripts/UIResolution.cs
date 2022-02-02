using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Aligning UI elements
/// </summary>
public class UIResolution : MonoBehaviour
{
    [SerializeField] private RectTransform _rect;
    [SerializeField] private CanvasScaler _scaler;
    private float _standartScale = 1731.282f;
    private void Start()
    {
        var scale = _rect.rect.height;
        if (scale == _standartScale || scale == 2215.607f)
        {
            _scaler.matchWidthOrHeight = 0;
        }
        else
        {
            _scaler.matchWidthOrHeight = 0.655f;
        }
    }
}
