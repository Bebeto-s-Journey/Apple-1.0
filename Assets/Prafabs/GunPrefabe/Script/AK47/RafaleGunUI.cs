using TMPro;
using UnityEngine;
public class RafaleGunUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    RafaleGun rafaleGun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rafaleGun = FindFirstObjectByType<RafaleGun>();
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = rafaleGun.amo.ToString();
    }
}
