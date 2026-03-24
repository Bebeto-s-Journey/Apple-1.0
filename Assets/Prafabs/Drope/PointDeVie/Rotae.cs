using UnityEngine;

public class Rotae : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(1 + Time.deltaTime, 1 + Time.deltaTime, 1 + Time.deltaTime);
    }
}
