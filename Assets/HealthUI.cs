using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxVelocityText;
    public TextMeshProUGUI damageOnHitText;
    public TextMeshProUGUI speedText;

    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        maxVelocityText = GetComponent<TextMeshProUGUI>();
        damageOnHitText = GetComponent<TextMeshProUGUI>();
        speedText = GetComponent<TextMeshProUGUI>();
    }

    //update the health text every three seconds
    private void Update()
    {
        InvokeRepeating("UpdateHealthText", 0f, 3f);
        InvokeRepeating("UpdateMaxVelocityText", 0f, 3f);
        InvokeRepeating("UpdateDamageOnHitText", 0f, 3f);
        InvokeRepeating("UpdateSpeedText", 0f, 3f);
    }

    public void UpdateHealthText(float health)
    {
        healthText.text = health.ToString();
    }

    public void UpdateMaxVelocityText(float maxVelocity)
    {
        maxVelocityText.text = maxVelocity.ToString();
    }

    public void UpdateDamageOnHitText(float damageOnHit)
    {
        damageOnHitText.text = damageOnHit.ToString();
    }

    public void UpdateSpeedText(float speed)
    {
        speedText.text = speed.ToString();
    }
}
