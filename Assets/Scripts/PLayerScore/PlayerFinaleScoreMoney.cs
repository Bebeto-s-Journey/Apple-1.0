using TMPro;
using UnityEngine;

public class PlayerFinaleScoreMoney : MonoBehaviour
{
    public static int money = 0;
    [SerializeField] private TextMeshProUGUI textMeshPro;   

    private void Start()
    {
        money = PlayerPrefs.GetInt("money", 0);
        money += UIDisplayDropable.money;
    }
    void Update()
    {
        PlayerPrefs.SetInt("money", money);
        textMeshPro.text = money.ToString(); 
    }
}
