using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "AK47", menuName = "Scriptable Objects/AK47")]
public class AK_47 : ScriptableObject
{
    public string id;
    public int amo;
    public float fireRate;
    public int damageTodeal;
    public float buletteSpeed;
    public int ennemyKilled;

    public void InCreaseAmo(int _amo)
    {
        amo += _amo;
        
    } 
    public void InCreaseFireRat(float _fireRate)
    {
        fireRate -= _fireRate;
        
    } 
    public void InCreaseDamage(int _damage)
    {
        damageTodeal += _damage;
        
    }

    public void SetEnnemyKilled(bool condition )
    {
        if (condition)
        ennemyKilled++;
    }

    public void Resete()
    {
        ennemyKilled = 0;
    }

    public void Restor(float fireRat, int damage, int amoe)
    {
        fireRate = fireRat;
        damageTodeal = damage;
        amo = amoe;
    }
}

    
