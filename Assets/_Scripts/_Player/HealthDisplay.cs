using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour, IObserver
{
    public HealthSystem healthSystem;
    public Text healthText;

    private void Start()
    {
        if (healthSystem != null)
        {
            healthSystem.Attach(this);
            UpdateObserver(); // Initialize display with current health
        }
    }

    private void OnDestroy()
    {
        if (healthSystem != null)
        {
            healthSystem.Detach(this);
        }
    }

    public void UpdateObserver()
    {
        healthText.text = "Health: " + healthSystem.Health;
    }
}
