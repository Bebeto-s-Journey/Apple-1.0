using UnityEngine;
using UnityEngine.UI;

public class HealthBare : MonoBehaviour
{
    [SerializeField] private Image foreGround;
    [SerializeField] private Image foreGroundInScene;

   public void HealthBarSysteme(float CurentHealth, float MaxHealth)
    {
        foreGround.fillAmount = CurentHealth / MaxHealth;
        foreGroundInScene.fillAmount = CurentHealth / MaxHealth;

    }
}
