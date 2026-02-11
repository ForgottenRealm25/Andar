using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health health;

    private void Start()
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }

    private void Update()
    {
        slider.value = health.currentHealth;
    }
}
