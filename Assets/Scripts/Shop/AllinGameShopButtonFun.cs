using UnityEngine;

public class AllinGameShopButtonFun : MonoBehaviour
{
    [SerializeField] private Canvas shop;
    [SerializeField] private Canvas pauseMenue;
    [SerializeField] private Canvas joyStike;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject pistolet;
    [SerializeField] private GameObject rafale;
    [SerializeField] private GameObject shorty;
    private bool shopIsOpend = false;
    private bool isPause = false;

    [SerializeField] private Animator rafalAn;
    [SerializeField] private Animator pistoleAn;
    [SerializeField] private Animator shortyAn;
    [SerializeField] private Animator coint;
    [SerializeField] private AudioSource au;


    public void Pause()
    {
        isPause = true;
        pauseMenue.enabled = isPause;
        Time.timeScale = 0.05f;

    }
    public void Continue()
    {
        isPause = false;
        pauseMenue.enabled = isPause;
        Time.timeScale = 1f;

    }

    
    public void OpenShoop()
    {
        shopIsOpend = true;
        Time.timeScale = 0.1f;

        coint.Play("Bounc");

    }
    private void Update()
    {

        shop.enabled = shopIsOpend;
        joyStike.enabled = !shopIsOpend;
        
        /////////////////////pause//////////////
       


    }
    public void CloseShop()
    {
        shopIsOpend = false;
        Time.timeScale = 1f;
        coint.Play("NotAnouthCoint");
    }


    // Buy Rafale
    public void BuyRafale()
    {
        if(UIDisplayDropable.money >= 20)
        {
            rafalAn.Play("onGunBuy");
            au.Play();
            Instantiate(rafale, spawnPoint.position, Quaternion.identity);
            UIDisplayDropable.money -= 20;
        }
        else
        {
            rafalAn.Play("CaintBuy");
        }

    }

    // Buy pistolet
    public void BuyPistolet()
    {
        if(UIDisplayDropable.money >= 10)
        {
            pistoleAn.Play("onGunBuy");
            au.Play();
            Instantiate(pistolet, spawnPoint.position, Quaternion.identity);
            UIDisplayDropable.money -= 10;  
        }else
        {
            pistoleAn.Play("CaintBuy");
        }

    }

    // Buy Short Gun
    public void BuyShortgun()
    {
        if (UIDisplayDropable.money >= 40)
        {
            shortyAn.Play("onGunBuy");
            au.Play();
            Instantiate(shorty, spawnPoint.position, Quaternion.identity);
            UIDisplayDropable.money -= 40;
        }else
        {
            shortyAn.Play("CaintBuy");
        }
    }



}
