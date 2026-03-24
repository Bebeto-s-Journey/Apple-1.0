using TMPro;
using UnityEngine;

public class ActiveWallUI : MonoBehaviour
{
    [SerializeField] private GameObject wallUiHolder;
    [SerializeField] private TextMeshProUGUI text;
    public static int wallColected;

    private void Start()
    {
        wallColected = 0;
        wallUiHolder.SetActive(false);
    }
    private void Update()
    {
        if(wallColected > 0)
        {
            wallUiHolder.SetActive(true);

        }
        else
        {
            wallUiHolder.SetActive(false);

        }


        // Show the number of wall colected 

        text.text = (wallColected + "");
    }

    
}
