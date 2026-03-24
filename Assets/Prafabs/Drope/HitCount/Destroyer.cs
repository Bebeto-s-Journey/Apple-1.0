using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyO()
    {
        Destroy(transform.parent.gameObject);
    }
}
