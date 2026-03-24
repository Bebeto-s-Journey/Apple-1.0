using UnityEngine;


public class WallTool : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles += new Vector3(0,0, Time.deltaTime * 50);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            ActiveWallUI.wallColected++; 
            Destroy(gameObject,0.01f);
        }
    }

}
