using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugPanelController : MonoBehaviour
{
    [SerializeField] 
    private GameObject debugPanel;
    [SerializeField] 
    private Slider speedSlider;
    [SerializeField] 
    private Slider maxHealthSlider;
    [SerializeField] 
    private Slider damageOnHitSlider;
    [SerializeField] 
    private Slider healingSpeedSlider;
    [SerializeField] 
    private Slider dragModifierSlider;
    [SerializeField] 
    private Slider accelerationModifierSlider;
    [SerializeField] 
    private Slider maxVelocitySlider;
    [SerializeField] 
    private PlayerController playerController;

    //public KeyCode toggleDebugPanel = KeyCode.P;
    
    public bool isDebugPanelActive = true;

  
    // Start is called before the first frame update
    void Start()
    {
        speedSlider.value = playerController.SPEED;
        maxHealthSlider.value = playerController.MAX_HEALTH;
        damageOnHitSlider.value = playerController.DAMAGE_ON_HIT;
        healingSpeedSlider.value = playerController.HEALING_SPEED;
        dragModifierSlider.value = playerController.DRAG_MODIFIER;
        accelerationModifierSlider.value = playerController.ACCELERATION_MODIFIER;
        maxVelocitySlider.value = playerController.MAX_VELOCITY;
        //set debug panel to active
        debugPanel.SetActive(true);

    }
// Update is called once per frame
void Update()
{
    
}


    public void OnSpeedChanged() {
    playerController.SPEED = speedSlider.value;
}

    public void OnMaxHealthChanged() {
        playerController.MAX_HEALTH = maxHealthSlider.value;
    }

    public void OnDamageOnHitChanged() {
        playerController.DAMAGE_ON_HIT = damageOnHitSlider.value;
    }

    public void OnHealingSpeedChanged() {
        playerController.HEALING_SPEED = healingSpeedSlider.value;
    }

    public void OnDragModifierChanged() {
        playerController.DRAG_MODIFIER = dragModifierSlider.value;
    }

    public void OnAccelerationModifierChanged() {
        playerController.ACCELERATION_MODIFIER = accelerationModifierSlider.value;
    }

    public void OnMaxVelocityChanged() {
        playerController.MAX_VELOCITY = maxVelocitySlider.value;
    }

}
