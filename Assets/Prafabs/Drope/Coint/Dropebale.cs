using UnityEngine;


public class Dropebale : MonoBehaviour
{
    
   // [SerializeField] private UIDisplayDropable displayeDropable;
    
    [SerializeField] private GameObject player;
    [SerializeField] private int mineyToGive;
    [SerializeField] private ParticleSystem cointPArticleVFX ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
     //   displayeDropable = FindAnyObjectByType<UIDisplayDropable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {

            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            float playerDistance = (player.transform.position - transform.position).magnitude;




            // move this object 
            if(playerDistance <= 8f)
            transform.Translate(playerDirection * 25 * Time.deltaTime, Space.World);

      


           
                if(playerDistance < 0.5)
                {

                    ParticleSystem coint = Instantiate(cointPArticleVFX, transform.position, Quaternion.identity);
                    coint.Play();

                    Destroy(this.transform.gameObject);
                    UIDisplayDropable.money += mineyToGive;
                }
        
        }

    }


}
