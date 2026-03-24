using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal; 
public class RafaleGun : MonoBehaviour, IAmo
{
    [Header("AK47 Data")]
    [SerializeField] private AK_47 aK47;

    [Header("Parametre De L'arme")]
    [Range(0f, 15f)]
    [SerializeField] private float detectionRang = 2;     
    [SerializeField] private AudioSource sound;     
    public static float fireRate;
   
    [SerializeField] private Transform nearestEnnemie;
    [SerializeField] public int amo; 
    [SerializeField] private bool canAim; 
    [SerializeField] private SpriteRenderer uiSprite; 
    [SerializeField] private SpriteRenderer visualeSpariteSprite; 
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private CircleCollider2D Collider;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Animator equipeAn;
    [SerializeField] private Image icon;
    [SerializeField] private Light2D lightT;


    private GameObject gunPos;

    [Header("Bullet to shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform SpownBuletPos;


    private GunClass gunClass;

    private void Awake()
    {
        aK47.Restor(0.8f, 1, 20);
        
    }
    private void Start()
    {
        gunPos = GameObject.FindGameObjectWithTag("PlayerGunPos");
        gunClass = new GunClass();
        amo = aK47.amo;
        fireRate = aK47.fireRate;
        bee = true;
        ennemyKilled = 0;
        aK47.Resete();

      
    }

    private void OnEnable()
    {
        LevelUpGuns.OnGunUpgrad += LevelUpGuns_OnGunUpgrad;
        ShalengeUIHandler.OnRifleUpdate += ShalengeUIHandler_OnRifleUpdate;
    }
    private void OnDisable()
    {
        LevelUpGuns.OnGunUpgrad -= LevelUpGuns_OnGunUpgrad;
        ShalengeUIHandler.OnRifleUpdate -= ShalengeUIHandler_OnRifleUpdate;
    }

    private void ShalengeUIHandler_OnRifleUpdate()
    {
        uiSprite = GunVisualeChenger.vusuale.RifleSprite;
        uiSprite.enabled = true;
        icon.color = uiSprite.color;
        visualeSpariteSprite.color = uiSprite.color;
        lightT.color = uiSprite.color;
    }



    private void LevelUpGuns_OnGunUpgrad()
    {
        UpdateGun();
    }
    

    public int ennemyKilled;

    public void AddNumberKilled()
    {
        aK47.SetEnnemyKilled(ShalengeUIHandler.rbee);
        LevelUpGuns.Fire_OnEnnemyKilled(this, new UniversalEventArgs(this));

    }

    public void UpdateGun()
    {
        amo = aK47.amo;
        fireRate = aK47.fireRate;
    }
    GameObject canvas;
    public AK_47 Data()
    {
        return aK47;
    }

    bool bee = true;
    private void Update()
    {

        
        fireRate = Mathf.Clamp(fireRate, 0.1f, 0.7f); 
        textMesh.text = amo.ToString();
        //ON pickUp
      if (gunPos != null)
      {

            if (this.transform.IsChildOf(gunPos.transform))
            {
                Collider.enabled = false;
                // Activer la UI 
                     canvas = this.gameObject.transform.Find("Canvas").gameObject;
                canvas.SetActive(true);
                if (bee == true)
                {
                    equipeAn.Play("Equipe");
                    bee = false;
                }

                // To aim 
                gunClass.GunAimSysteme(detectionRang, transform,ref canAim, ref uiSprite, ref nearestEnnemie, ref layerMask);
                SpownBuletPos.transform.right = transform.right;
               // gunClass.TimeElaps(ref timeElaps, ref canAim);
                // To Shoot
                Shoot();
            }else
            {
                
               
                if(canvas != null)
                {
                    Collider.enabled = true;
                    canvas.SetActive(false);
                    bee = true;


                }

            }
               
      }
        
    }

    public Vector3 spawnNuletteOffSet;


   private void TOResolveDecalleBullet()
    {
        if(uiSprite.flipY)
        {
            spawnNuletteOffSet = SpownBuletPos.position;
            
        }
        else
        {
            
            spawnNuletteOffSet = transform.position;

        }
    }

    private float nextTimeTOAim;
    private float timeElaps;


    private void Shoot()
    {
        TOResolveDecalleBullet();

        if (amo > 0 )
        {
            if (canAim) 
            {
                    if (Time.time >= nextTimeTOAim)
                    {
                       
                        timeElaps = 0;
                        sound.Play();
                        
                        Instantiate(bullet, spawnNuletteOffSet, transform.rotation);
                        amo--;

                    nextTimeTOAim = Time.time + fireRate;
                    }
                    
                    
                    
            }
            else
            {

                      
                        
                        nextTimeTOAim = Time.time + fireRate;
            }

        }
        else
        {

            // Destroy(transform.gameObject, 1);
            textMesh.color = Color.red;

        }
    }



    public void AddAmo(int amoToAdd)
    {

        amo += amoToAdd;
    }
    // Randre visible la zonne de detection de l'arme dans léditeur
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




