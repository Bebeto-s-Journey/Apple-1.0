using UnityEngine;
using System;

public class OnPLayerIsDead : MonoBehaviour
{
   
    public EventHandler OnPlayerDead;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawner;

    void Start()
    {
       
    }

   

    void Update()
    {
        if(player == null)
        {
            OnPlayerDead?.Invoke(this, EventArgs.Empty);
            
        }
    }

    
}
