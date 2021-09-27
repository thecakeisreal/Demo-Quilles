using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script g�rant l'information sur la boule
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

    // Repositionne la boule � son endroit initial
    public void ReinitialiserPosition()
    {
        transform.position = positionInitiale;
        transform.rotation = rotationInitiale;

        // R�initialisation du d�placement
        Rigidbody compRigidbody = GetComponent<Rigidbody>();

        compRigidbody.velocity = Vector3.zero;
        compRigidbody.angularVelocity = Vector3.zero;
    }
}
