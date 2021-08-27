using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsable de créer de nouvelles quilles
public class FabriqueQuille : MonoBehaviour
{
    // On crée 10 quilles par défaut
    public const int NOMBRE_QUILLES = 10;

    // Position de la quille de tête, les autres quilles sont placés derrière (orienté vers le z positif)
    public Vector3 positionPremiereQuille;

    // Modèle de quille
    public GameObject prototypeQuille;

    // Référence vers les quilles créées
    public GameObject[] quilles;

    // Start is called before the first frame update
    void Start()
    {
        CreerQuilles();
    }

    // Crée et dispose un nombre de quilles selon la valeur de la constante NOMBRE_QUILLES
    public void CreerQuilles()
    {
        GameObject quille = Instantiate(prototypeQuille);
        quille.transform.position = positionPremiereQuille;
    }
}
