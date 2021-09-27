using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script gérant l'information sur la boule
public class Boule : MonoBehaviour
{
    // Position et rotation intiales de la boule
    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;

    // Start is called before the first frame update
    void Start()
    {
        // On lit les valeurs de l'inspecteur
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;
    }

    // Repositionne la boule à son endroit initial
    public void ReinitialiserPosition()
    {
        transform.position = positionInitiale;
        transform.rotation = rotationInitiale;

        // Réinitialisation du déplacement
        Rigidbody compRigidbody = GetComponent<Rigidbody>();

        compRigidbody.velocity = Vector3.zero;
        compRigidbody.angularVelocity = Vector3.zero;
    }
}
