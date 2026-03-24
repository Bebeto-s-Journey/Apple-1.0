using UnityEngine;
using UnityEngine.UI;

public class ShowHelth 
{
    public void DisplayHealthForEnnemie(Image image, float courentHealth, float maxtHealth, Image greenHealthbare = null)
    {
        image.fillAmount = courentHealth / maxtHealth;
        if (greenHealthbare != null)
        {

            if (image.fillAmount < 1 )
            {
                greenHealthbare.enabled = false;
            }
        }
    }
}
