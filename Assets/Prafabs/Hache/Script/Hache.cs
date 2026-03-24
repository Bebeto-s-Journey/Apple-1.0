using UnityEngine;


public class Hache : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform rayPosition;
    [SerializeField] private LayerMask layer;
    [SerializeField] private int damageToDeal;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private AudioClip[] sounds;
   

    private void Start()
    {
       
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ennemie"))
        {
           if(collision.TryGetComponent(out EnnemieInterface ennemie) )
            {
               
                ennemie.IDamageble(damageToDeal);
            }
        }
        
    }

    private void Update()
    {
      

        DetectionRang();
    }


    private void DetectionRang()
    {
        Collider2D hit = Physics2D.OverlapCircle(rayPosition.position, 6f, layer);
        if (hit != null)
        {
            if (hit.transform.CompareTag("Ennemie"))
            {
                animator.SetBool("IsAttaking", true);
              


            }
        }
        else
        {

            animator.SetBool("IsAttaking", false); 
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rayPosition.position, 6f);
    }


    [SerializeField] public AudioSource au;
    public void PlaySong()
    {

        au.clip = sounds[0];
        au.Play(); 
    }

   
    private void PlayHitSong()
    {
        au.clip = sounds[1];
        au.Play();
    }
}
