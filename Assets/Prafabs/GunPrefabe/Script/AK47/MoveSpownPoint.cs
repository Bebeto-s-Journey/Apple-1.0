using UnityEngine;

public class MoveSpownPoint : MonoBehaviour
{
     float amplitude = 0.08f; // L'amplitude de l'oscillation
     float frequency = 50f; // La fréquence de l'oscillation

    private Vector3 startPosition;

    void Start()
    {
        // Enregistrer la position de départ de l'objet
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculer le déplacement en utilisant Mathf.Sin
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Appliquer le déplacement à la position de l'objet
        transform.position = startPosition + new Vector3(offset, 0, 0);
    }
}

   


