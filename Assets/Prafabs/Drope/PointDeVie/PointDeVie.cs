using UnityEngine;

public class PointDeVie : MonoBehaviour
{
    private Transform player;
    
    [SerializeField]
    private ParticleSystem healEffect;
    [SerializeField]
    private float healthToGive = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    private void Update()
    {
        

        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if(distance <= 18f && HealthB.HealthBInstance.currentHealth < HealthB.HealthBInstance.maxHealth)
            {
                transform.Translate(direction * 25  * Time.deltaTime, Space.World);
                if(distance < 0.5f)
                {
                    // Add player health
                    if((HealthB.HealthBInstance.maxHealth - HealthB.HealthBInstance.currentHealth) < healthToGive ) // verfier l'atat de la bar de vie pour ajouter just ce qu'il faut
                    {

                        HealthB.HealthBInstance.SetCurrentHealth(HealthB.HealthBInstance.maxHealth);

                    }
                    else
                    {
                        HealthB.HealthBInstance.AddCurrentHealth(healthToGive);

                    }

                    // Destroy 
                    Instantiate(healEffect, transform.position, Quaternion.identity);
                    Destroy(transform.gameObject);
                }
            }

        }

    }

}
