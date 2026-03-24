using UnityEngine;

public class GunBulet : MonoBehaviour
{
   
     public static int damageToDeal;

    private void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Avancer dans la direction de l'axe X local, en tenant compte de la rotation
       /* Vector3 direction = new Vector3(transform.right.x, transform.right.y, 0).normalized;
        transform.position += direction * speedShot * Time.deltaTime;
    */}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ennemie"))
        {
            collision.TryGetComponent(out EnnemieInterface ennemieInterface);
            if (ennemieInterface != null)
            {
                ennemieInterface.IDamageble(damageToDeal);

            }


        }

    }
}
