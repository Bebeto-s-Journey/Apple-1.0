
using UnityEngine;


public class GunClass 
{
   

    public void AimSysteme(Collider2D collision, GameObject Gun, SpriteRenderer sprite = null)
    {
        
        // Mettre un System de prioriter. Si un ennemie est plus puissant le visseur point vers luis 
    

            Vector3 ennemiePos = collision.transform.position;
            Vector3 aimDirection = (ennemiePos - Gun.transform.position).normalized;
            Gun.transform.right = aimDirection;
        
            // Flipe the gun by using the transform rotation

            var angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            if (sprite == null)
            {
                Vector2 localScale = Vector2.one;

                if(angle > 90 || angle < -90)
                {
                    localScale.y = -1;
                }else
                {
                    localScale.x = 1;
                }
                Gun.transform.localScale = localScale;
            }
            if(sprite != null)
            {
                
                if(angle > 90 || angle < -90)
                {
                    sprite.flipY = true; 
                }else
                {
                    sprite.flipY = false;
                }
            }


            

        
    }
    public void TimeElaps(ref float timeElaps, ref bool triggered)
    {
        if (triggered)
        {
            timeElaps += Time.deltaTime;
        }
        else
        {
            timeElaps = 0;
        }
    }
   
        private float timeElaps= 0;

    public void GunAimSysteme(float detectionRadius, Transform Gun, ref bool triggered, ref SpriteRenderer sprite , ref Transform nearestEnnemie, ref LayerMask layerMask)
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(Gun.position, detectionRadius, layerMask);

        float minDistance = Mathf.Infinity;
        timeElaps += Time.deltaTime;
        foreach (Collider2D collider in colliderArray)
        {

            if(timeElaps >= 0.3f)
            {

                if (collider != null && collider.CompareTag("Ennemie"))
                {
                  float distance = Vector2.Distance(Gun.position, collider.transform.position);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnnemie = collider.transform;
                    }

                }
                 if(collider == null )
                {
                    nearestEnnemie = null;
                }
                timeElaps = 0;
            }
        }
       
        if (nearestEnnemie != null)
        {
            triggered = true;

            Vector3 _aimDirection = (nearestEnnemie.position - Gun.position).normalized;
            var angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
            Gun.right = _aimDirection;
      

            // flip the uiSprite to evoid weard 360 rotaion
           /* if (uiSprite == null)
            {
                Vector2 localScale = Vector2.one;

                if (angle > 90 || angle < -90)
                {
                    localScale.y = -1;
                }
                else
                {
                    localScale.x = 1;
                }
                Gun.transform.localScale = localScale;
            }*/
            if (sprite != null)
            {

                if (angle > 90 || angle < -90)
                {
                    sprite.flipY = true;
                }
                else
                {
                    sprite.flipY = false;
                }
            }

           
        }
        else
        {
            triggered = false;
         
        }
    }
}
