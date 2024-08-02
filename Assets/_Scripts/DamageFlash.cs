using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.5f;
    public Color flashColor = new Color(1, 0, 0, 0.5f);

    private Color originalColor;
    private float flashTimer;

    void Start()
    {
        if (flashImage == null)
        {
            flashImage = GetComponent<Image>();
        }
        originalColor = flashImage.color;
        flashImage.color = Color.clear;
    }

    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            flashImage.color = Color.Lerp(flashColor, originalColor, flashTimer / flashDuration);
        }
        else
        {
            flashImage.color = originalColor;
        }
    }

    public void Flash()
    {
        flashTimer = flashDuration;
        flashImage.color = flashColor;
    }
}
