using UnityEngine;

public class wallButton : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Transform spowPos;


    private void Start()
    {

    }

    private void Update()
    {

    }
    public void SetWall()
    {
        if(ActiveWallUI.wallColected > 0)
        {
            // Instantiate a wall at the front of the player 

            Instantiate(wall, spowPos.position, wall.transform.rotation);



            // reinitialize wallColected
            ActiveWallUI.wallColected--;
        }
    }
}
