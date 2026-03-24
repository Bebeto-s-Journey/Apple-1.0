using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int damageToAdd;
    private int fireRateToAdd;
    private int amoToAdd;
    
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<AK_47> gun;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

 

    public void EnheceGun( string id)
    {

        if(PlayerFinaleScoreMoney.money >= 100)
        {
            gun.Find(x => x.id == id).InCreaseAmo(6);   
            gun.Find(x => x.id == id).InCreaseDamage(1);
            gun.Find(x => x.id == id).InCreaseFireRat(0.1f);
            PlayerFinaleScoreMoney.money -= 100;
        }
    }
    public void AddAmo(string id)
    {
        
        gun.Find(x => x.id == id).InCreaseAmo(6);   
    }
    public void AddDamage(string id)
    {
        gun.Find(x => x.id == id).InCreaseDamage(1);
    }
    public void AddFireRate(string id)
    {
        gun.Find(x => x.id == id).InCreaseFireRat(0.1f);
    }


   
    
}
