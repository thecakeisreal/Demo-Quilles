using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// D�tecte quelles quilles sont tomb�es
public class DetecteurQuilles : MonoBehaviour
{
    // Compteur de quilles tomb�es
    public int NbQuillesTombees { get; private set; }

    // �v�nement indiquant qu'une quille est tomb�e
    // La quille tomb�e est celle pass�e en param�tre
    public event Action<Quille> quilleTombee;

    // Initialisation avant l'affichage � l'�cran
    private void Awake()
    {
        NbQuillesTombees = 0;
    }

    // Quilles sortent du d�tecteur
    private void OnTriggerExit(Collider other)
    {
        // On v�rifie que la quille a le bon tag
        if(other.gameObject.transform.tag == "Quille")
        {
            NbQuillesTombees++;
            // Lance l'�v�nement. Tous les �couteurs (listener) sont notifi�s et leur m�thode est appel�e.
            quilleTombee?.Invoke(other.gameObject.GetComponent<Quille>());
        }
    }
}
