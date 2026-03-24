using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NormaleEnnemies : MonoBehaviour, EnnemieInterface
{
  

    // public EnnemiesBaseClass ennemies;

    [Header("Object to sspawn after die")]
    [SerializeField] 
    private GameObject money;
    [SerializeField] 
    private GameObject medic;
    [Header("nombre de vie du player")]
    private ShowHelth healthBare = new ShowHelth();
    [SerializeField] 
    private int maxHealth = 20;
    [SerializeField] 
    private float courantHealth;
    [SerializeField]
    [Header("nombre de degat a faire et vitess de deplacement ")]
    private int damageToDeal;
    [SerializeField] 
    private int followSpeed;
    [SerializeField] 
    private Image health;
    [SerializeField]
    private float hitEffectDuration;
    [SerializeField] 
    private Material material;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField] 
    private LayerMask layerMask;
    [SerializeField]
    private ParticleSystem healthEffect;

    [SerializeField] 
    private Image greenhealth;
    private bool haveHealth;

    private Player player;
    GameObject _player;

    [SerializeField]
    private GameObject hit;
    [SerializeField]
    private ParticleSystem particleDamage;
    [SerializeField] private Transform soinPos;
    [SerializeField] private GameObject soin;

   [SerializeField] private TextMeshProUGUI HealthText;


    private void Awake()
    {
    }
    private void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            player = _player.GetComponent<Player>();
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }

        courantHealth = maxHealth;
        material = sprite.material;

        haveHealth = CanDropHealth();
        MarqueAsHealthCarrier();


    }

    private void Update()
    {
        HealthText.text = $"{courantHealth} / {maxHealth} ";

        FollowPlayer(followSpeed);

        healthBare.DisplayHealthForEnnemie(health, courantHealth, maxHealth, greenhealth);  // Display And Upgrate Health bare

       


    }

    private void FollowPlayer( int _speed)
    {
        
        if (_player != null)
        {

                float distance = (_player.transform.position - transform.position).magnitude;
                Vector2 direction = (_player.transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, layerMask); // le ray est pour le mure

            Debug.DrawRay(transform.position, direction, Color.red, 0.5f);

            if (distance > 5)
            {
                if(hit.transform != null) 
                    transform.position += Vector3.zero;
                else 
                    transform.Translate(direction * _speed * Time.deltaTime, Space.World);
                
              

            }
            else
            {
                
                transform.position += Vector3.zero;

                _player.transform.TryGetComponent(out EnnemieInterface Iinterface);
                Iinterface.IDamageble(damageToDeal * Time.deltaTime);
            }

        }

        


    }

    private bool CanDropHealth()
    {
        int _random = Random.Range(0, 3);

        return _random == 1;
    }

    private void MarqueAsHealthCarrier()
    {
        if (haveHealth)
        {
            GameObject soint = Instantiate(soin, soinPos.position, Quaternion.identity);
            soint.transform.SetParent(soinPos);
            healthEffect.Play();
        }
    }

    private void DestryAndSpawn()
    {
        if (courantHealth <= 0)
        {
            if (haveHealth)
            {
                Instantiate(medic, transform.position + new Vector3(0, 3, 0), Quaternion.identity);
               

            }
            courantHealth = 0;
            Instantiate(money, transform.position, Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
    }

    private void OnDestroy()
    {
        ScoreAfterDeadOrWin.N2_numberOfEnnemyKilled++;
        UIDisplayDropable.snakeKilled++;
        if (player == null) return;
        if (player.Gun() == null)
        {
            return;
        }
        Debug.Log("HaveGun");

        player.Gun().TryGetComponent(out IAmo component);

        component.AddNumberKilled();

    }

    public void IDamageble(float damageTaken)         // Damage this object
    {
       

        Instantiat(damageTaken.ToString());
        ParticleSystem bleed = Instantiate(particleDamage, transform.position, Quaternion.identity);  // Instatiate the bleed vfx and play it
        bleed.Play();

        courantHealth -= damageTaken;
        StartCoroutine(HitEffect());
        DestryAndSpawn();


    }


    public void Instantiat(string hitAmoune)
    {
        GameObject _hit = Instantiate(hit, transform.position, Quaternion.identity);
        
        TextMeshProUGUI text = hit.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "-" + hitAmoune;
    }


    private IEnumerator HitEffect()
    {
        float timeElaps = 0;
        float curentflachAmount = 0;
        while (timeElaps < hitEffectDuration)
        {
            
            timeElaps += Time.deltaTime;

            curentflachAmount = Mathf.Lerp(1f, 0f, timeElaps /  hitEffectDuration);
            material.SetFloat("_FlashAmount", curentflachAmount);
            yield return null;
        } 
    }


}
