using System;
using UnityEngine;

public class BiomeLogic : MonoBehaviour
{
  [SerializeField] private Spawner2 spawner;
  [SerializeField] private GameObject mapLogic;
  [SerializeField] private GameObject biomeCamera;
  [SerializeField] private BoxCollider2D _collider;
  [SerializeField] private GameObject pointer;

    private void Start()
    {
        spawner.OnLevelFinished += DeactivateLevelOnFinished;
    }

    private void DeactivateLevelOnFinished(object sender, EventArgs Empty)
    {
       pointer.SetActive(true);
        biomeCamera.SetActive(false);
        Destroy(mapLogic, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {

            pointer.SetActive(false);
            biomeCamera.SetActive(true);           
            mapLogic.SetActive(true);
            _collider.enabled = false;
        }

    }
}
