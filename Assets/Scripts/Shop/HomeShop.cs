using UnityEngine;

public class HomeShop : MonoBehaviour
{
    [SerializeField]
    private Canvas shop;
    private bool isOpend = false;
    void Start()
    {
            
    }


    public void OpendShop()
    {
        isOpend = true;
    }
    public void CloseShop()
    {
        isOpend = false;
    }

    // Update is called once per frame
    void Update()
    {
        shop.enabled = isOpend;
    }
}
