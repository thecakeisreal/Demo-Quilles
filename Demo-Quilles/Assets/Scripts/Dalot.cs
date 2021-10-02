using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// D�tecte que la boule est hors du jeu et en informe le contr�leur
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
