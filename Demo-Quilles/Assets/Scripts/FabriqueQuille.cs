using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe responsable de créer de nouvelles quilles
public class FabriqueQuille : MonoBehaviour
{
    public static FabriqueQuille Instance { get; private set; }

    // On crée 10 quilles par défaut
    public const int NOMBRE_QUILLES = 10;

    // Position de la quille de tête, les autres quilles sont placés derrière (orienté vers le z positif)
    public Vector3 positionPremiereQuille;

    // Modèle de quille
    public Quille prototypeQuille;

    // Référence vers les quilles créées
    public Quille[] quilles;

    // Valeur pour espacer les quilles
    public float decalageColonne;
    public float decalageLigne;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        quilles = new Quille[NOMBRE_QUILLES];

        CreerQuilles();
    }

    // Crée et dispose un nombre de quilles selon la valeur de la constante NOMBRE_QUILLES
    public void CreerQuilles(bool releverToutesLesQuilles = false)
    {
        int ligne = 0, colonne = 0;
        Vector3 pos = positionPremiereQuille;

        for (int i = 0; i < NOMBRE_QUILLES; i++)
        {
            // Réutilise les quilles existantes / Crée une nouvelle quille au besoin
            if (quilles[i] == null)
            {
                quilles[i] = Instantiate(prototypeQuille);    
            }

            // On travaille sur une référence plutôt que la valeur du tableau (simplicité)
            Quille quille = quilles[i];

            // Désactive les quilles tombées ou laisse active celles debouts
            quille.gameObject.SetActive(releverToutesLesQuilles || !quille.EstTombee);
            

            // Applique les positions et rotations de base à la quille
            quille.transform.position = pos;
            quille.transform.rotation = Quaternion.identity;

            colonne++;
            if (colonne > ligne)
            {
                ligne++;
                colonne = 0;
            }

            // Position de la prochaine quille
            pos = positionPremiereQuille + new Vector3(
                colonne * decalageColonne
                - (ligne % 2) * decalageColonne * 0.5f 
                - (ligne - ligne % 2) * decalageColonne * 0.5f, 
                0f, ligne * decalageLigne);
            
        }
    }
}
