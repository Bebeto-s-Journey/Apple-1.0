using UnityEngine;

public class WallToInstantiate : MonoBehaviour
{
    [SerializeField] private int duration;
    void Start()
    {
        duration = 15;
        Destroy(gameObject, duration);       
    }

   
}
