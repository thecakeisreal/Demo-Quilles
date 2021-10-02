using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Détecte que la boule est hors du jeu et en informe le contrôleur
public class Dalot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boule")
        {
            ControleurJeu.Instance.PartirCompteurFinTour();
        }
    }
}
