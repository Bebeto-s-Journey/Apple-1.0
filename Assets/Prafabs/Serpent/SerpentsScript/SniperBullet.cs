using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] LayerMask ScreenCollider;
    [SerializeField] int speed = 20;
    [SerializeField] int damangeToDeal;

    // Update is called once per frame

    private void Start()
    {
   
    }

    void Update()
    {
        transform.position += new Vector3(transform.right.x, transform.right.y, 0) * speed * Time.deltaTime;
        
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, .5f, ScreenCollider);
        Debug.DrawRay(transform.position, transform.position, Color.yellow, .5f);
        if (hit.collider != null)
        {

           
            if (hit.collider.gameObject.CompareTag("WallScreenCollider"))
            {

                     
                Destroy(transform.gameObject);
            }
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                hit.transform.TryGetComponent(out EnnemieInterface Iinterface);
                Iinterface.IDamageble(damangeToDeal);
                Destroy(transform.gameObject);

            }
        }
        
    }
}
