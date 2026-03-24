using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    public Joystick joystick;
    

    public static Player PlayerInstance { get; private set; }






    [SerializeField] private Transform gunPos;
    [SerializeField] private GameObject throwGun;
    [SerializeField] private ShakCamera shakCamera;

    public IAmo amo;

    [SerializeField] private Transform hach;
    public LayerMask player;
    public LayerMask collision;
    [SerializeField] private Canvas barHealthInScene;
    private float lastjoystickMove;
    private void Start()
    {
        PlayerInstance = this;  
        throwGun.SetActive(false);
    }

   
    public Transform Gun()
    {
        return gunPos.childCount > 0 ? gunPos.GetChild(0) : null;   
    }
    void Update()
    {
        if(gunPos.childCount == 0)
            throwGun.SetActive(false);

        speed = Mathf.Clamp(speed, 15, 22);
        // Health();
        PlayerMvement();
        PickUpGun();

        // healthBare.HealthBarSysteme(curentHealth, maxHealth);

        if (joystick.Direction.x != 0)
        {
            lastjoystickMove = joystick.Direction.x;

        }

        if (amo != null && amo.GetAmo() <= 0)
        {
            throwAN.Play("Throw");
        }
    }

    

    public void PlayerMvement()
    {
        transform.position += HandleScreenEdgCollider();
        hach.localScale = new Vector2(Mathf.Sign(lastjoystickMove), hach.localScale.y);
    }

    private GameObject hite;
    public Canvas DestroyGun;
    private Canvas marchantShop;
    public void PickUpGun()
    {
        // Utiliser un Ray pour collecter les arms et autre

        Vector2 rayDirection = joystick.Direction.normalized;
        float rayDistence = 1.5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1.5f, 0), rayDirection, rayDistence, player);
        Debug.DrawRay(transform.position + new Vector3(0, -1.5f, 0), rayDirection, Color.red, rayDistence);


            
        if (hit.transform != null)
        {

            hite = hit.transform.gameObject;
            if (hit.transform.CompareTag("Gun"))
            {
                if (gunPos.childCount < 1)
                {
                    hite.transform.SetParent(gunPos.transform);
                    hite.transform.position = gunPos.transform.position;
                    throwGun.SetActive(true);
                    audioD.Play();
                    hite.transform.TryGetComponent(out amo);
                }
                else                
                {
                    DestroyGun.enabled = true;

                }
                if(gunPos.childCount == 0)
                {

                    throwGun.SetActive(false);
                }
            }
            else
            {
                DestroyGun.enabled = false;
            }


            if ( hite.transform.CompareTag("Personnage"))
            {
                marchantShop = hite.transform.Find("Canvas").GetComponent<Canvas>();
                marchantShop.enabled = true;
            }
        }
        else
        {
            DestroyGun.enabled = false;
            if(marchantShop != null)    
            marchantShop.enabled = false;
        }


    }

   

    public void ChangeGunToAmo()
    {
        gunPos.GetChild(0).transform.TryGetComponent(out IAmo amo);
        amo.AddAmo(9);
        Destroy(hite.gameObject);
    }


    private Vector3 HandleScreenEdgCollider()
    {

        //// Collider Systeme
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1.5f, joystick.Direction, 1f, collision);

        Vector3 movement;
        if (hit.transform != null)
        {
            movement = Vector3.zero;
        }
        else
        {

            movement = new Vector3(joystick.Direction.x, joystick.Direction.y, 0).normalized;
        }
        return movement * Time.deltaTime * speed;


        /*
        if(transform.position.x <= -43)
        {
            transform.position = new Vector3(-transform.position.x - 9,transform.position.y,0);
        }if(transform.position.x >= 43)
        {
            transform.position = new Vector3(-transform.position.x + 9,transform.position.y,0);
        }
        if(transform.position.y <= -58)
        {
            transform.position = new Vector3(transform.position.x,-transform.position.y - 7,0);
        }if(transform.position.y >= 58)
        {
            transform.position = new Vector3(transform.position.x ,-transform.position.y + 7,0);
        }*/
    }
    [SerializeField] private Transform dropGunPos;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioD;
    [SerializeField] private Animator throwAN;

    public void ThrowGun()
    {

        GameObject gun = gunPos.GetChild(0).gameObject;
        gun.transform.position = dropGunPos.position;
        gun.transform.SetParent(null);
        throwGun.SetActive(false);

        audioS.Play();


    }



    public void SetSpeed(float speed)
    {
        this.speed += speed;
    }
}
