using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    #region Singleton
    public static ScreenShaker _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }
    #endregion //!Singleton

    private Transform camTransform;

    // Duration of the screen shake
    private float shakeDuration = 0f;

    // Amplitude of the shake
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

    Vector3 originalPos;


    void OnEnable()
    {
        camTransform = Camera.main.transform;
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void TriggerShake(float duration, float amount)
    {
        shakeDuration = duration;
        shakeAmount = amount;
    }
}
