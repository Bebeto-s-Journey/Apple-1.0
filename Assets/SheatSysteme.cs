using UnityEngine;
using UnityEngine.UI;

public class SheatSysteme : MonoBehaviour
{
    public static SheatSysteme CheatInstance;

    [SerializeField] private GameObject cheatPanel;
    [SerializeField] private Toggle haveInfinitHealth;
    public bool infinitHealth;   

    private void Start()
    {
        CheatInstance = this;
        cheatPanel.SetActive(false);
    }

    private void Update()
    {
        infinitHealth =  haveInfinitHealth.isOn;

       
    }

    bool panelIsOpen = false;
    public void OpenPanel()
    {
        panelIsOpen = !panelIsOpen;
        cheatPanel.SetActive(panelIsOpen);
    }

    public void AddMoney(int toAdd)
    {
        UIDisplayDropable.money += toAdd;
    }

   
}
