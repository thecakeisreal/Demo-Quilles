using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Détecte quelles quilles sont tombées
public class DetecteurQuilles : MonoBehaviour
{
    // Compteur de quilles tombées
    public int NbQuillesTombees { get; private set; }

    // Événement indiquant qu'une quille est tombée
    // La quille tombée est celle passée en paramètre
    public event Action<Quille> quilleTombee;

    // Initialisation avant l'affichage à l'écran
    private void Awake()
    {
        NbQuillesTombees = 0;
    }

    // Quilles sortent du détecteur
    private void OnTriggerExit(Collider other)
    {
        // On vérifie que la quille a le bon tag
        if(other.gameObject.transform.tag == "Quille")
        {
            NbQuillesTombees++;
            // Lance l'événement. Tous les écouteurs (listener) sont notifiés et leur méthode est appelée.
            quilleTombee?.Invoke(other.gameObject.GetComponent<Quille>());
        }
    }
}
