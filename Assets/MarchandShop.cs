using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarchandShop : MonoBehaviour
{




    [SerializeField] private TextMeshProUGUI _speedToGet;
    [SerializeField] private TextMeshProUGUI _speedValue;
    [SerializeField] private int speedValue;
    [SerializeField] private int speedToGet;


    [SerializeField] private TextMeshProUGUI _healthToGet;
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private Image lockImage;
    [SerializeField] private Animator buySpeed;
    [SerializeField] private Animator buyHealth;
    [SerializeField] private Animator coint;

    [SerializeField] private int healthValue;
    [SerializeField] private int healthToGet;

    private void Start()
    {
        bee = 0;
        tee = true;
        lee = false;
    }

    [SerializeField] private Canvas marchandShop;
    int bee = 0;
    bool tee = true;
    bool lee = false;

    private void Update()
    {
        _speedToGet.text = $" + {speedToGet}";
        _speedValue.text = $"{speedValue}x";

        _healthToGet.text = $" + {healthToGet}";
        _healthValue.text = $" {healthValue}x";
        if (marchandShop.enabled)
        {
            coint.Play("Bounc1");
            lee = true ;

        }else if (!marchandShop.enabled & lee)
        {
            coint.Play("NotAnouthCoint");
            lee = false;
        }
        
    }

    public void CloseMarcahndShop()
    {
        marchandShop.enabled = false;
    }

    public void BuySpeed()
    {
        if(UIDisplayDropable.money > speedValue && tee)
        {
            UIDisplayDropable.money -= speedValue;
            Player.PlayerInstance.SetSpeed(speedToGet);
            buySpeed.Play("OnStateBuy");
            bee++;
            if (bee >= 4)
            {
                tee = false;
                lockImage.enabled = true;
            }
        }else
        {
            buySpeed.Play("CaintBuyMarchant");
        }
    }

    public void EnhenceMaxHealth()
    {
        if (UIDisplayDropable.money > healthValue)
        {
            UIDisplayDropable.money -= healthValue;
            HealthB.HealthBInstance.AddMaxHealth(healthToGet);
            buyHealth.Play("OnStateBuy");
        }else
        {
            buyHealth.Play("CaintBuyHealth");
        }
    }
}
