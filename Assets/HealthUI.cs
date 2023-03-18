using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealthText(float health)
    {
        healthText.text = health + "%";
    }
}
