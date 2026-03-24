using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SniperEnnemies : MonoBehaviour, EnnemieInterface
{
    [Header("Health")]
    [SerializeField]
    private float courentHealth;
    [SerializeField]
    private float maxtHealth;
    [Header("vitess de movement")]
    [SerializeField] 
    private int moveSpeed;
    [Header("other")]

    [SerializeField]
    private GameObject health;
    [SerializeField]
    private Material materiale;
    [SerializeField]
    private float hitEffectDuration;
    [SerializeField] 
    private GameObject sniperBulets;

    [SerializeField] 
    private LayerMask layerMask;    
    [SerializeField] 
    private GameObject money;
    [SerializeField] 
    private SpriteRenderer sprite;
    
    private ShowHelth healthBar = new ShowHelth();
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private GameObject spownPoint;

    private bool canAttaque;

    private GameObject bullet;
    [SerializeField]
    private GameObject hit;
    [SerializeField]
    private ParticleSystem bleed;
    [SerializeField]
    private Image greenBareHealth;
    [SerializeField]
    private ParticleSystem healthEffect;
    [SerializeField]
    private bool haveHealth;
    [SerializeField] private Transform soinPos;
    [SerializeField] private GameObject soin;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private int damangeToDeal = 3;
    GameObject _player;
    private Player player;
    private EnnemieInterface Iinterface;

    private void Awake()
    {
        canAttaque = false;
        
        courentHealth = maxtHealth;
        
        materiale = sprite.material;

        haveHealth = CanDropHealth();
        MarqueAsHealthCarrier();
        _player = GameObject.FindGameObjectWithTag("Player");
        player = _player.transform.GetComponent<Player>();
        _player.transform.TryGetComponent(out Iinterface);
    }



    void Update()
    {
        HealthText.text = $"{courentHealth} / {maxtHealth} ";
        FollowPlayerAndAttque(moveSpeed);
        healthBar.DisplayHealthForEnnemie(healthImage, courentHealth, maxtHealth, greenBareHealth);

    }
    public bool isBoss;
    private void FollowPlayerAndAttque(int _speed)//, Collider2D _collider)
    {



        if (_player != null)
        {
            float distance = (_player.transform.position - transform.position).magnitude;
            Vector2 direction = (_player.transform.position - transform.position).normalized;

            var playerRadAngl = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, playerRadAngl));

            spownPoint.transform.rotation =  rotation;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, layerMask);



            if (distance > 15f)
            {

                if (hit.transform != null)
                    transform.position += Vector3.zero;
                else
                    transform.Translate(direction * _speed * Time.deltaTime, Space.World);


            }
            else if (distance < 10f)
            {
                transform.Translate(-direction * _speed * Time.deltaTime, Space.World);
               
                if(isBoss)
                Iinterface.IDamageble(damangeToDeal);
                sprite.flipX = true;
            }
            else
            {
                // Cette ennemie netire que si il est a une certaine distance de mon player

                canAttaque = bullet == null || distance == 6f; // Pour quil puisse tirer il faut que la ball quil a tirer precedament soit detruit en touchent mon player ou en srtant du cadre de l'ecrant
                transform.position += Vector3.zero;
                if (canAttaque)
                {
                    bullet = Instantiate(sniperBulets, spownPoint.transform.position, spownPoint.transform.rotation);

                    sprite.flipX = false;
                    canAttaque = false;

                }
            }
        }
    }



         private float GetAngle(Transform transformA, Transform transformB)
         {
            var Direction = (transformA.position - transformB.position).normalized;
            var Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
           

            return Angle;
         }

    private bool CanDropHealth()
    {
        int _random = Random.Range(0, 10);

        return _random == 1;
    }

    private void MarqueAsHealthCarrier()
    {
        if(haveHealth)
        {
            GameObject soint = Instantiate(soin, soinPos.position, Quaternion.identity);
            soint.transform.parent = soinPos.transform;
            healthEffect.Play();
        }
    }
    
    private void DestroyEndSpawn()
    {
        if (courentHealth <= 0)
        {
            if (haveHealth)
            {
                Instantiate(health, transform.position, Quaternion.identity);
               

            }
            courentHealth = 0;
            Instantiate(money, transform.position, Quaternion.identity);
            Instantiate(money, transform.position + new Vector3(2, 0, 0), Quaternion.identity);

            Destroy(this.transform.gameObject);
        }
    }

    private void OnDestroy()
    {
        ScoreAfterDeadOrWin.N2_numberOfEnnemyKilled++;
        UIDisplayDropable.snakeKilled++;
        if (player == null) return;
        if (player.Gun() == null) return;
        player.Gun().TryGetComponent(out IAmo component);
        
        component.AddNumberKilled();

    }
    public void IDamageble(float damageTaken)
    {

        courentHealth -= damageTaken;

        Instantiat(damageTaken.ToString());
        ParticleSystem _bleed = Instantiate(bleed, transform.position, Quaternion.identity);  /// Instantiate bleed VFX and Play it
        _bleed.Play();
        StartCoroutine(HitEffect());
        DestroyEndSpawn();
       

    }
    public void Instantiat(string hitAmoune)
    {
        GameObject _hit = Instantiate(hit,transform.position, Quaternion.identity);
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

            curentflachAmount = Mathf.Lerp(1f, 0f, timeElaps / hitEffectDuration);
            materiale.SetFloat("_FlashAmount", curentflachAmount);
            yield return null;
        }
    }


}



