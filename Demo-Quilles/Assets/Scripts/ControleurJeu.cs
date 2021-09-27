using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gère la logique du jeu et le tour du joueur
public class ControleurJeu : MonoBehaviour
{
    public const int NOMBRE_LANCERS = 21;

    // Délai d'attente après la dernière quille tombée pour indiquer la fin du tour
    public float delaiAttenteQuille;

    // Incrémanté à chaque frame pour compter le temps écoulé
    private float tempsAttenteEcoule;

    // Délai attente de quille tombée activé par première quille qui tombe
    private bool delaiActif;

    // Objet détectant les quilles tombées
    public DetecteurQuilles detecteurQuille;

    // Référence sur la boule de quille
    public Boule boule;

    // Nombre de quilles tombees par tour
    private int[] nombreQuillesTombees;

    // Numéro du tour joué
    private int tour;

    // Référence du joueur
    public Joueur joueur;

    // Start is called before the first frame update
    void Start()
    {
        tour = 0;
        nombreQuillesTombees = new int[NOMBRE_LANCERS];

        // Inscrit la méthode à l'événement lancé par détecteur quille
        detecteurQuille.quilleTombee += GererQuilleTombee;
    }

    private void OnDestroy()
    {
        // Évite d'appeler la méthode si l'objet est détruit
        detecteurQuille.quilleTombee -= GererQuilleTombee;
    }

    // Appelé lorsqu'une quille tombe
    private void GererQuilleTombee(Quille quille)
    {
        // On réinitialise le temps d'attente pour attendre 4 secondes après que la dernière quille soit tombée
        tempsAttenteEcoule = 0f;
        quille.EstTombee = true;

        if (!delaiActif)
        {
            delaiActif = true;
            StartCoroutine("GererDelaiAttente");
        }
    }

    // Coroutine comptant le temps d'attente écoulé
    private IEnumerator GererDelaiAttente()
    {
        while (tempsAttenteEcoule < delaiAttenteQuille)
        {
            tempsAttenteEcoule += Time.deltaTime;
            yield return null;      // Attend la prochaine frame avant de continuer l'exécution de la fonction
        }

        // Avancement de tour
        nombreQuillesTombees[tour] = detecteurQuille.NbQuillesTombees;
        // Si abat avant le 18e tour
        if (nombreQuillesTombees[tour] == FabriqueQuille.NOMBRE_QUILLES && tour % 2 == 0
            && tour < NOMBRE_LANCERS - 3)
        {
            tour += 2;
        }
        else
        {
            tour++;
        }

        // Relever les quilles
        bool releverToutesLesQuilles = false;
        if (tour % 2 == 0 && tour <= NOMBRE_LANCERS - 3)
        {
            releverToutesLesQuilles = true;
        }
        else if (tour >= NOMBRE_LANCERS - 3 && nombreQuillesTombees[tour - 1] == FabriqueQuille.NOMBRE_QUILLES)
        {
            releverToutesLesQuilles = true;
        }
        Debug.Log(detecteurQuille.NbQuillesTombees);

        // Réinitialisation des objets
        boule.ReinitialiserPosition();
        joueur.ReinitialiserJoueur();
        FabriqueQuille.Instance.CreerQuilles(releverToutesLesQuilles);

        Debug.Log("Prochain tour " + tour);
    }
}
