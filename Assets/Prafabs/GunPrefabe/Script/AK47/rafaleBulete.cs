using UnityEngine;

public class rafaleBulete : MonoBehaviour
{

    [Header("AK47 Data")]
    [SerializeField] private AK_47 aK47;
    [SerializeField] private float speedShot;
    [SerializeField] private int damageToDeal;
    [SerializeField] private LayerMask ScreenCollider;

    private void Start()
    { 
        damageToDeal = aK47.damageTodeal;
        speedShot = aK47.buletteSpeed;   

        Destroy(gameObject, 3);
    }
    
    void Update()
    {
        speedShot = 110 - ( RafaleGun.fireRate * 100)  ;

        // Avancer dans la direction de l'axe X local, en tenant compte de la rotation
        Vector3 direction = new Vector3(transform.right.x, transform.right.y, 0).normalized;
        transform.position += direction * speedShot * Time.deltaTime;



        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, .5f, ScreenCollider);
        Debug.DrawRay(transform.position, transform.position, Color.yellow, .5f);
        if (hit.collider != null)
        {
          
            if (hit.collider.gameObject.CompareTag("WallScreenCollider"))
            {


                Destroy(transform.gameObject);
            }
            if (hit.collider.gameObject.CompareTag("Ennemie"))
            {
                if (hit.transform.TryGetComponent(out EnnemieInterface ennemiInterface))
                {
                    ennemiInterface.IDamageble(damageToDeal);
                }
               
                    Destroy(transform.gameObject);

            }
        }
    }

   

}
            