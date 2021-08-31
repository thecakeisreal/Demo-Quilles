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

    // Valeur pour espacer les quilles
    public float decalageColonne;
    public float decalageLigne;

    // Start is called before the first frame update
    void Start()
    {
        quilles = new GameObject[NOMBRE_QUILLES];

        CreerQuilles();
    }

    // Crée et dispose un nombre de quilles selon la valeur de la constante NOMBRE_QUILLES
    public void CreerQuilles()
    {
        int ligne = 0, colonne = 0;
        Vector3 pos = positionPremiereQuille;

        for (int i = 0; i < NOMBRE_QUILLES; i++)
        {
            GameObject quille = Instantiate(prototypeQuille);
            quille.transform.position = pos;

            colonne++;
            if (colonne > ligne)
            {
                ligne++;
                colonne = 0;
            }

            // Position de la prochaine quille
            pos = positionPremiereQuille + new Vector3(colonne * decalageColonne - (ligne % 2) * decalageColonne * 0.5f - 0.5f * (ligne - ligne % 2) * decalageColonne, 0f, ligne * decalageLigne);
            quilles[i] = quille;
        }
    }
}
