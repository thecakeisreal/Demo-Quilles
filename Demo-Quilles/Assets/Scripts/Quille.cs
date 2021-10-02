using UnityEngine;

// Script gérant l'information sur une Quille
public class Quille : MonoBehaviour
{
    // État de la quille
    public bool EstTombee { get; set; }

    // Réinitialise les valeurs de la quille pour la positionner correctement sur le jeu
    public void Reinitialiser(bool relever, Vector3 position)
    {
        if (relever)
        {

            EstTombee = false;
        }

        // Applique les positions et rotations de base à la quille
        transform.position = position;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}

