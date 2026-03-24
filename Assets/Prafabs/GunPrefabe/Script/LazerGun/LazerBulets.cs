using UnityEngine;

public class LazerBulets : MonoBehaviour
{


    [SerializeField] int damageToDeal;
    

    private void Start()
    {
        damageToDeal = 1;
        transform.gameObject.SetActive(false);
    }
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

   
        if (collision.CompareTag("Ennemie")) {

           if(collision.TryGetComponent(out EnnemieInterface ennemieInterface))
            {

                     ennemieInterface.IDamageble(damageToDeal);
            }
           
           

            
           
        }
        

    }

}




