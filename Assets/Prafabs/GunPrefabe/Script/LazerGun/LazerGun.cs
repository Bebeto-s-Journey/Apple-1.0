using UnityEngine;

using TMPro;


// Le probleme ave le systeme de viser ces que si il y a beaucoup d'ennemie le viseur s'afole 



// Pour les arme faire de sort que plus le nobre de degat augment plus l'aspect visuel change 
// Exemple : pour le bullet plus les degats augmente plus il vire au rouge et plus le song change
public class LazerGun : MonoBehaviour, IAmo
{

    [Range(0f, 15f)]
    public float detectionRang = 2;
    [SerializeField] private GameObject gunPos;
    [SerializeField] TextMeshProUGUI textMeshPro;
    private bool canAim;
    [SerializeField] private float fireRat = 1f;
    [SerializeField] private GameObject effetDeTire;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform nearestEnnemie;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private CircleCollider2D Collider;
    [SerializeField] private AudioSource audio1;

    [SerializeField] private Animator equipeAn;

    public int amo;

    private GunClass gunClass;
    private void Start()
    {
        gunClass = new GunClass();
        gunPos = GameObject.FindGameObjectWithTag("PlayerGunPos");
        bee = true;


    }

  
    public void AddNumberKilled()
    {
    }

    GameObject canvas;
    bool bee = true;
     public float timer = 0;
    private void Update()
    {

        
        
        textMeshPro.text = amo.ToString();
        
     
       if( gunPos != null)
       {

            if (this.transform.IsChildOf(gunPos.transform))
            {
                Collider.enabled = false;
                canvas = this.gameObject.transform.Find("Canvas").gameObject;
                canvas.SetActive(true);
                timer = 0;
                if (bee == true)
                {
                    equipeAn.Play("EquipeP");
                    bee = false;
                }

                // To aim
                gunClass.GunAimSysteme(detectionRang, transform, ref canAim, ref sprite, ref nearestEnnemie, ref layerMask);
               // gunClass.TimeElaps(ref timeElaps, ref canAim);
                // Shoot 
                Shoot();
            }
            else
            {
                if (canvas != null)
                {
                    timer += Time.deltaTime;
                    canvas.SetActive(false);
                    bee = true;
                    if (timer > 0.3)
                    {
                        Collider.enabled = true;
                        timer = 0.4f;

                    }
                   

                }

            }
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


    private float nextTimeToShoot;
    private float timeBeforeDeactivate = 0.1f;
    private float timeEldapsed;


    private float timeElaps;
    private void Shoot()
    {
        if (amo > 0)
        {
            if( canAim)
            {
                if (Time.time >= nextTimeToShoot)
                {
                    timeEldapsed = 0;
                    effetDeTire.SetActive(true);
                    timeElaps = 0;
                    amo--;

                    nextTimeToShoot = Time.time + fireRat;
                    audio1.Play();
                }
                else
                {
                    if (timeEldapsed >= timeBeforeDeactivate)
                    {
                        effetDeTire.SetActive(false);
                        

                    }
                    else
                    {
                        
                        timeEldapsed += Time.deltaTime;
                    }
                       
                }
            }
            else
            {

                nextTimeToShoot = Time.time + fireRat;
                effetDeTire.SetActive(false);
                timeEldapsed = 0;
               // nextTimeToShoot = Time.time + fireRate;
            }
            
        }
        else
        {
            effetDeTire.SetActive(false);
            //  Destroy(this.transform.gameObject, 1);
            textMeshPro.color = Color.red;
        }
    }


    public int GetAmo()
    {
        return amo;
    }
}
