using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameHUB
{

    
    public class PlayerMovement
    {
        
        public static void MovePlayerWithRigidbody(Vector2 moveDirection, Rigidbody2D rb, float moveSpeed)
        {


            rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            

        }
        public static void MovePlayerWithRigidbody(Vector2 moveDirection, Rigidbody rb, float moveSpeed)
        {


            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
            

        }
    }

    public class ExtraUtile : MonoBehaviour
    {

      
       
        public static void FlipeByScale(float movementInput, Transform transform)
        {
             transform.localScale = new Vector3(Mathf.Sign(movementInput) , transform.localScale.y);
        }
        public static void FlipeByDirectionVector( Transform FlipTriggerer, Transform ObjectToFlipe, SpriteRenderer SpriteRenderer)
        {
            Vector2 direction = (FlipTriggerer.position - ObjectToFlipe.position).normalized;

            if(direction.x > 0 )
            {
                SpriteRenderer.flipX = true;
            }
            else
            {
                SpriteRenderer.flipX = false;

            }
           
        }
        public static void FlipeByDirectionVectorScale( Transform FlipTriggerer, Transform ObjectToFlipe)
        {
            Vector2 direction = (FlipTriggerer.position - ObjectToFlipe.position).normalized;

           
               ObjectToFlipe.localScale = new Vector3(Mathf.Sign( -1 * direction.x), ObjectToFlipe.localScale.y);
           
           
        }
    }

    public class Find
    {
         
       
        public static int NumberOf(string tag)
        {

            if (!string.IsNullOrEmpty(tag))
            {

                GameObject[] _tag = GameObject.FindGameObjectsWithTag(tag);

                return _tag.Length;
            }
            return 0;

        }

        public static GameObject[] Objects(string tag)
        {

            if (!string.IsNullOrEmpty(tag))
            {
                
                GameObject[] gameObject_tag = GameObject.FindGameObjectsWithTag(tag);

                return gameObject_tag;
            }
            
            return null;

        }

        public static GameObject Object(string tag)
        {
            if(!string.IsNullOrEmpty(tag))
            {
                GameObject player = GameObject.FindGameObjectWithTag(tag);
                return player;
            }
            return null;
        }
    }


   /* public class Transfer : MonoBehaviour
    {
        public static void Components(GameObject a , GameObject b) 
        {

            // Get all components in a
            Component[] AComponents;
            AComponents = a.GetComponents<Component>();


            // Get all components in b
            Component[] BComponents;
            BComponents = b.GetComponents<Component>();
            //Destroy components in b
            *//*for (int i = 2; i < BComponents.Length; i++)
            {

                Destroy(BComponents[i]);

            }*//*




            // add a components to b 


            AComponents.CopyTo(BComponents, 2);

            


            
        }

      
    }
*/
}
