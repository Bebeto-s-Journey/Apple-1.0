using UnityEngine;
using Unity.Cinemachine;

public class ShakCamera : MonoBehaviour
{
    public static  ShakCamera shakCamera;
    [SerializeField]
    private CinemachineImpulseSource impulseSource;
   

    public void ShakeCamera(float impulsForce) // Have only One reference witch is player
    {
        //impulseSource.DefaultVelocity = shakeDirection;
        impulseSource.GenerateImpulseWithForce(impulsForce * 2 );
    }
}
