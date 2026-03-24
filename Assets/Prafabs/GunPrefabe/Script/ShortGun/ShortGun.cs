using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal; 
public class ShortGun : MonoBehaviour, IAmo 
{
    [Header("AK47 Data")]
    [SerializeField] private AK_47 shorty;


    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private ShakCamera shakCamera;

    [SerializeField] public int amo;
    private GunClass gunClass;
    [SerializeField] private Transform nearestEnnemie;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private SpriteRenderer visualeSprite;
    [SerializeField] private AudioSource sound;
    [SerializeField] private GameObject bulet;
    [SerializeField] private bool canAim;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private CircleCollider2D Collider;
    [SerializeField] private Image icon;
    [SerializeField] private Light2D lights;

    [SerializeField] private Animator equipeAn;

    [SerializeField] private bool isEquiped;
    [SerializeField] private GameObject gunPos;
    [Range(0f, 15f)]
    public float detectionRang = 2;

    private void Awake()
    {
        shorty.Restor(1.8f, 2, 9);
        shorty.Resete();


    }
    private void Start()
    {
        amo = shorty.amo;
        fireRate = shorty.fireRate;
        shakCamera = FindAnyObjectByType<ShakCamera>();
        
        GunBulet.damageToDeal = shorty.damageTodeal;
        gunClass = new GunClass();
        gunPos = GameObject.FindGameObjectWithTag("PlayerGunPos");
        bee = true;

        sprite = GunVisualeChenger.vusuale.ShortySprite;


        
    }

    private void LevelUpGuns_OnGunUpgrad()
    {
        UpdateGun();
    }

    public void AddNumberKilled()
    {
        shorty.SetEnnemyKilled( ShalengeUIHandler.stee);
        LevelUpGuns.Fire_OnEnnemyKilled(this, new UniversalEventArgs(this));
        
    }
    public void UpdateGun()
    {
        fireRate = shorty.fireRate;
        amo = shorty.amo;
    }

    public AK_47 Data()
    {
        return shorty;
    }


    private void OnEnable()
    {
        LevelUpGuns.OnGunUpgrad += LevelUpGuns_OnGunUpgrad;
        ShalengeUIHandler.OnShortyUpdate += ShalengeUIHandler_OnShortyUpdate;
    }
    private void OnDisable()
    {
        LevelUpGuns.OnGunUpgrad -= LevelUpGuns_OnGunUpgrad;
        ShalengeUIHandler.OnShortyUpdate -= ShalengeUIHandler_OnShortyUpdate;
    }
    private void ShalengeUIHandler_OnShortyUpdate()
    {
        sprite = GunVisualeChenger.vusuale.ShortySprite;
        sprite.enabled = true;
        icon.color = sprite.color;
        visualeSprite.color = sprite.color;
        lights.color = sprite.color;
    }

    private GameObject canvas;
    private float timer;
    bool bee = true;
    private void Update()
    {
        textMeshPro.text = amo.ToString();

        if (gunPos != null)
        {

            isEquiped = this.transform.IsChildOf(gunPos.transform);

            if (isEquiped)
            {

                Collider.enabled = false;
                // show canvas 

                canvas = this.gameObject.transform.Find("Canvas").gameObject;
                canvas.SetActive(true);
                timer = 0;
                if (bee == true)
                {
                    equipeAn.Play("EquipeS");
                    bee = false;
                }

                // trigger shoot fontion

                gunClass.GunAimSysteme(detectionRang, transform, ref canAim, ref sprite, ref nearestEnnemie, ref layerMask);
                //gunClass.TimeElaps(ref timeElapsed, ref canAim);
                // To Shoot
                Shoot();
            }
            else
            {
                if (canvas != null)
                {
                    timer += Time.deltaTime;
                    canvas.SetActive(false);
                    if (timer > 0.3)
                    {
                        Collider.enabled = true;
                        timer = 0.4f;
                        bee = true;

                    }
                }
            }
        }

        // to aime

    }

    public float timePassedToDeactivate;
    private float nextFireTime;
   
    private void Shoot()
    {


                      


        if (amo > 0)
        {
            if (canAim)
            {
                    float timeBefoforSetFale = 0.2f;
                       

                if(Time.time >= nextFireTime)
                {
                    timePassedToDeactivate = 0f;
                    bulet.SetActive(true);
                    sound.Play();
                    amo -= 3;
                    shakCamera.ShakeCamera(2);
                    nextFireTime = Time.time + fireRate;
                    
                }else
                {
                    if(timePassedToDeactivate >= timeBefoforSetFale)
                    {
                        bulet.SetActive(false);

                    }
                    else
                    {
                        timePassedToDeactivate += Time.deltaTime;

                    }
                      
                    
                }
            }
            else
            {
                    timePassedToDeactivate = 0f;
                    nextFireTime = Time.time + fireRate;
               
                    bulet.SetActive(false);
                    

            }
        }
        else
        {
           // Destroy(this.transform.gameObject, 1);
            bulet.SetActive(false);
            textMeshPro.color = Color.red;


        }


    }

    
    public void AddAmo(int amoToAdd)
    {

        amo += amoToAdd;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRang);

    }

    public int GetAmo()
    {
        return amo;
    }
}
