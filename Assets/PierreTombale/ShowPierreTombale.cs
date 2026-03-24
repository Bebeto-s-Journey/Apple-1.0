using UnityEngine;

public class ShowPierreTombale : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pierre;
   
    void Start()
    {
        
    }

   
    void Update()
    {

        if (player == null)
        {
           pierre.SetActive(true);
        }
        else
        {
            transform.position = player.position;

        }
    }
}
