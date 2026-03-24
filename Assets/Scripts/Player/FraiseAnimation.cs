using UnityEngine;

public class FraiseAnimation : MonoBehaviour
{
    private Player player;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>(); 
      
    }


    private void Update()
    {
       
           animator.SetBool("IsWalking", player.joystick.Direction != Vector2.zero);
     

        
        if(player.joystick.Direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(player.joystick.Direction.x < 0)
        {
            spriteRenderer.flipX = true;
            
        }
    }
}
