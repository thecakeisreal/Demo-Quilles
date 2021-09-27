using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
