using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MAX_HEALTH;
    [SerializeField]
    private float DAMAGE_ON_HIT;
    [SerializeField]
    private float HEALING_SPEED;

    [SerializeField]
    private float health = 100;


    private bool healing = false;
    private bool blocked = false;

    public float topSpeed;
    public float accelerationSpeed;
    private float speed;

    private float deathFloat;
    public float deathSpeed;
    public Material blitMat;

    private bool hasDied;


    [SerializeField]
    private MusicManagerController musicManagerController;

    public GameObject playerVisuals;


    // private Rigidbody rigidbody;
    float timeInLight;

    [SerializeField]
    float maxTimeInLight;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = gameObject.GetComponent<Rigidbody>();
        hasDied = false;
        deathFloat = -1f;
        blitMat.SetFloat("_DeathFloat", deathFloat);
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





        if (healing && health < 100 && !blocked)
        {
            health += HEALING_SPEED * Time.deltaTime;
        }

        HealthUI healthUI = FindObjectOfType<HealthUI>();
        if (healthUI != null)
        {
            healthUI.UpdateHealthText(health);
        }


        if (!healing)
        {
            timeInLight += Time.deltaTime;
            if (timeInLight >= maxTimeInLight)
            {
                musicManagerController.PlayTheme(MusicManagerController.Theme.Broken);
            }
            // if (!dragging){
            //     transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED;
            // } else {
            //     transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0) * SPEED / DRAG_MODIFIER;
            // }


            if (health <= 0)
            {
                
                playerVisuals.active = false;
                if (!hasDied)
                    musicManagerController.PlaySound(MusicManagerController.Sound.Death);
                hasDied = true;

                deathFloat = Mathf.Lerp(deathFloat, 1.1f, deathSpeed * Time.deltaTime);
                blitMat.SetFloat("_DeathFloat", deathFloat);
                Debug.Log("HEY");

                if (deathFloat > 1f)
                {
                    //Switch to other scene
                    SceneManager.LoadScene("MainMenu");
                }
            }
            if (!healing) {
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
    }
    void OnTriggerEnter(Collider collider)
        {
            
            Debug.Log("TriggerEnter");
        if (!hasDied)
        {
            if (collider.gameObject.tag == "Obstacle")
            {
                // Debug.Log("Hit an obstacle!");
                musicManagerController.PlaySound(MusicManagerController.Sound.Hit);
                health -= DAMAGE_ON_HIT;
            }
            else if (collider.gameObject.tag == "Serenity")
            {
                // Debug.Log("I'm in serenity");
                healing = true;
                musicManagerController.PlayTheme(MusicManagerController.Theme.Dark);
                musicManagerController.PlaySound(MusicManagerController.Sound.IntoSerenity);
            }
            else if (collider.gameObject.tag == "Border")
            {

            }
            if (collider.gameObject.tag == "SerenityBlocker")
            {
                musicManagerController.PlaySound(MusicManagerController.Sound.SerenityBlocked);
                blocked = true;
            }
        }

        }

        void OnTriggerExit(Collider collider)
        {
            Debug.Log("TriggerExit");
            if (collider.gameObject.tag == "Serenity")
            {
                // Debug.Log("I'm in noise");
                musicManagerController.PlayTheme(MusicManagerController.Theme.Light);
                musicManagerController.PlaySound(MusicManagerController.Sound.IntoNoise);
                healing = false;
            }
            if (collider.gameObject.tag == "SerenityBlocker")
            {
                blocked = false;
            }

        
    }
}