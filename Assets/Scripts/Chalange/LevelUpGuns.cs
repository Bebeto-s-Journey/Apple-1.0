using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;

public class LevelUpGuns : MonoBehaviour
{
    public static event EventHandler<UniversalEventArgs> OnEnnemyKilledGetKiller;
    [SerializeField] private List<ChalengeSetUp> chalenges;
    public static event Action OnGunUpgrad;




    public int shortyEnnemyKilled;
    public int rafaleEnnemyKilled;
    private void Start()
    {
        OnEnnemyKilledGetKiller += Guns_OnEnnemyKilledGetKiller;
    }

    public List<ChalengeSetUp> GetcurrentChalange()
    {
        List<ChalengeSetUp> bee = new List<ChalengeSetUp>();
            bee.Add(chalenges[0]);
            bee.Add(chalenges[1]);

        return chalenges.Count >= 2 ? bee : null;
    }

    public void ClearChalenges()
    {
        if (chalenges.Count >= 2)
        {
            chalenges.RemoveAt(1);
            chalenges.RemoveAt(0);
        }
    }

    private void Guns_OnEnnemyKilledGetKiller(object sender,UniversalEventArgs obj)
    {
        CheckGunNumberKilled(obj);
        ValidateChalange(obj);
    }


    public static void Fire_OnEnnemyKilled(object sender, UniversalEventArgs obj)
    {
        OnEnnemyKilledGetKiller?.Invoke(sender, obj);
    }

    private void CheckGunNumberKilled(UniversalEventArgs obj)
    {
        System.Object bee = obj.data;
        if (obj == null) return;
        
        if (bee is ShortGun)
        {

            ShortGun shortGun = (ShortGun)bee;

            shortyEnnemyKilled = shortGun.Data().ennemyKilled;
            
        }
        if (bee is RafaleGun)
        {
            RafaleGun rafalGun = (RafaleGun)bee;

            rafaleEnnemyKilled = rafalGun.Data().ennemyKilled;

        }
    }
    bool bee;

    
    private void ValidateChalange(UniversalEventArgs obj)
    {
        chalenges.ForEach(ch =>
        {
            
            if (ch.isRafaleChalange)
            {
                ch.UpdateGun(obj, rafaleEnnemyKilled);
                if(rafaleEnnemyKilled >= ch.killeRequired)
                OnGunUpgrad?.Invoke();


            }
            if (ch.isShortyChalange)
            {
                ch.UpdateGun(obj, shortyEnnemyKilled);
                if (shortyEnnemyKilled >= ch.killeRequired)
                    OnGunUpgrad?.Invoke();

            }


        });



    }

}

[Serializable]
public class ChalengeSetUp
{
    public float encreasdamageTo, reduceFireRateTo, ecreaseAmoTo;

    public int killeRequired;

    public bool isShortyChalange;
    public bool isRafaleChalange;
    public bool completed = false;
    public static event Action OnGunUpgraded;
    public bool GetState()
    {
        return completed;
    }

    public void UpdateGun(UniversalEventArgs obj, int amountKilled)
    {
        if (isRafaleChalange && isShortyChalange) throw new Exception("Chalenge should be eater 'isRafaleChalange' or 'isShortyChalange'");
        if (amountKilled < killeRequired) return;

        System.Object bee = obj.data;
        if (bee is ShortGun && isShortyChalange)
        {
                ShortGun shortGun = (ShortGun)bee;

                if(shortGun.Data().fireRate >= 0.5f && !completed)
                {
                    shortGun.Data().InCreaseFireRat(reduceFireRateTo);
                    shortGun.Data().InCreaseDamage((int)encreasdamageTo);
                    shortGun.Data().InCreaseAmo((int)ecreaseAmoTo);
                    shortGun.Data().Resete();
                    completed = true;
                    if(completed)
                        OnGunUpgraded?.Invoke();

                 }
        }
            if (bee is RafaleGun && isRafaleChalange )
            {
                RafaleGun rafalGun = (RafaleGun)bee;

                if (rafalGun.Data().fireRate >= 0.2f && !completed)
                {
                    rafalGun.Data().InCreaseFireRat(reduceFireRateTo);
                    rafalGun.Data().InCreaseDamage((int)encreasdamageTo);
                    rafalGun.Data().InCreaseAmo((int)ecreaseAmoTo);
                    rafalGun.Data().Resete();
                    completed = true;
                    if (completed)
                        OnGunUpgraded?.Invoke();
                }
            }
    }
}

public class UniversalEventArgs : EventArgs
{
    public System.Object data;
    public int ennemyKilled;

    public UniversalEventArgs(System.Object data)
    {
        this.data = data; 
    }
}