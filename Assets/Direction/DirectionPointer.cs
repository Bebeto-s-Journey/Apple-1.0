using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private Transform target;                                                                                       

    private void Update()
    {
       LookAt();
    }

    private void LookAt()
    {
        Vector2 direction = target.position - transform.position;

        float angl = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angl);
    }
}
