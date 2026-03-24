using TMPro;
using UnityEngine;

public class HealthB : MonoBehaviour, EnnemieInterface
{
    public float maxHealth {  get; private set; }
    public float currentHealth {  get; private set; }
    [SerializeField] private HealthBare healthBare;
    [SerializeField] private Canvas barHealthInScene;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private ShakCamera shakCamera;

    public static HealthB HealthBInstance { get; private set; }  
    private void Awake()
    {
        HealthBInstance = this;
        maxHealth = 20;
        currentHealth = maxHealth;
        healthText.text = $"{(int)currentHealth} / {(int)maxHealth}";

    }

    private void Update()
    {
        barHealthInScene.enabled = currentHealth < maxHealth;
        healthBare.HealthBarSysteme(currentHealth, maxHealth);

    }

    public void IDamageble(float DamageTaken)
    {
        healthText.text = $"{(int)currentHealth} / {(int)maxHealth}";
        Die();
        shakCamera.ShakeCamera(DamageTaken);
        currentHealth -= DamageTaken;
    }

    private void Die()
    {
        if (currentHealth <= 0 /*&& SheatSysteme.CheatInstance.infinitHealth == false*/)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }

    public void AddMaxHealth(float healthToAdd)
    {
        this.maxHealth += healthToAdd;
    }
    public void SetMaxHealth(float healthToAdd)
    {
        this.maxHealth = healthToAdd;
    }
    public void AddCurrentHealth(float healthToAdd)
    {
        this.currentHealth += healthToAdd;
    }
    public void SetCurrentHealth(float healthToAdd)
    {
        this.currentHealth = healthToAdd;
    }
}
