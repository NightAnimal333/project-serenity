using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float SPEED;

    [SerializeField]
    public float MAX_HEALTH;
    [SerializeField]
    public float DAMAGE_ON_HIT;
    [SerializeField]
    public float HEALING_SPEED;

    [SerializeField]
    public float DRAG_MODIFIER;
    [SerializeField]
    public float ACCELERATION_MODIFIER;

    [SerializeField]
    public float health = 100;

    [SerializeField]
    public float MAX_VELOCITY = 1000;



    private bool healing = false;
    private bool blocked = false;

    public float topSpeed;
    public float accelerationSpeed;
    private float speed;

    [SerializeField]
    private MusicManagerController musicManagerController;

    float timeInLight;

    [SerializeField]
    float maxTimeInLight;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float hInput = Convert.ToSingle(Input.GetKey(KeyCode.D)) - Convert.ToSingle(Input.GetKey(KeyCode.A));

        float targetSpeed = hInput * topSpeed;
        if (blocked)
            targetSpeed = -topSpeed;

        float x = gameObject.transform.position.x;
        if (x >= 14)
            targetSpeed = -topSpeed;
        else if (x <= -4)
            targetSpeed = topSpeed;

        speed = Mathf.Lerp(speed, targetSpeed * Time.deltaTime, accelerationSpeed * Time.deltaTime);

        gameObject.transform.position += new Vector3(speed, 0f, 0f);


        }

        if (healing && health < 100 && !blocked){
            health += HEALING_SPEED * Time.deltaTime;
        }

        // Update health, speed, velocity, and damage on hit text from HealthUI

        HealthUI healthUI = FindObjectOfType<HealthUI>();
        if (healthUI != null)
        {
            healthUI.UpdateHealthText(health);
            healthUI.UpdateSpeedText(SPEED);
            healthUI.UpdateMaxVelocityText(MAX_VELOCITY);
            healthUI.UpdateDamageOnHitText(DAMAGE_ON_HIT);

        }


        if (!healing)
        {
            timeInLight += Time.deltaTime;
            if (timeInLight >= maxTimeInLight)
            {
                musicManagerController.PlayTheme(MusicManagerController.Theme.Broken);
            }
        }
        else
        {
            timeInLight = 0;
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("TriggerEnter");
        if (collider.gameObject.tag == "Obstacle"){
            // Debug.Log("Hit an obstacle!");
            musicManagerController.PlaySound(MusicManagerController.Sound.Hit);
            health -= DAMAGE_ON_HIT;
        }
        else if (collider.gameObject.tag == "Serenity"){
            // Debug.Log("I'm in serenity");
            healing = true;
            musicManagerController.PlayTheme(MusicManagerController.Theme.Dark);
            musicManagerController.PlaySound(MusicManagerController.Sound.IntoSerenity);
        } else if (collider.gameObject.tag == "Border"){

        }
        if (collider.gameObject.tag == "SerenityBlocker"){
            musicManagerController.PlaySound(MusicManagerController.Sound.SerenityBlocked);
            blocked = true;
        }

    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("TriggerExit");
        if (collider.gameObject.tag == "Serenity"){
            // Debug.Log("I'm in noise");
            musicManagerController.PlayTheme(MusicManagerController.Theme.Light);
            musicManagerController.PlaySound(MusicManagerController.Sound.IntoNoise);
            healing = false;
        }
        if (collider.gameObject.tag == "SerenityBlocker"){
            blocked = false;
        }

    }
}
