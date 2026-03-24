using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System;

public class EnnemiesBaseClass 
{
    public int health { get; private set; }
    public int damageToDeal { get; private set; }
    public void Health(int normaleEnnemieMaxHealth)
    {
        health = normaleEnnemieMaxHealth;

    }
    public int DamageToDeal(int _damageToDeal)
    {
        damageToDeal = _damageToDeal;
        return damageToDeal;
    }
   /* public void Damageble(int _damageTaken)
    {
        curentHealth -= _damageTaken;
        if (curentHealth < 0) curentHealth = 0;
    }*/

   /* public bool IsAlive()
    {
        return curentHealth > 0;
    }*/
}


