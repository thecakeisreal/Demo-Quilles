using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// G�re la logique du jeu et le tour du joueur
public class ControleurJeu : MonoBehaviour
{
    // Impl�mentation du singleton
    public static ControleurJeu Instance { get; private set; }

    public const int NOMBRE_LANCERS = 21;
    public const int NOMBRE_CARREAU = (NOMBRE_LANCERS - 1) / 2;

    // D�lai d'attente apr�s la derni�re quille tomb�e pour indiquer la fin du tour
    public float delaiAttenteQuille;

    // Incr�mant� � chaque frame pour compter le temps �coul�
    private float tempsAttenteEcoule;

    // D�lai attente de quille tomb�e activ� par premi�re quille qui tombe
    private bool delaiActif;

    // Objet d�tectant les quilles tomb�es
    public DetecteurQuilles detecteurQuille;

    // R�f�rence sur la boule de quille
    public Boule boule;

    // Nombre de quilles tombees par tour
    private int[] nombreQuillesTombees;

    // Num�ro du tour jou�
    private int tour;

    // R�f�rence du joueur
    public Joueur joueur;

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
        tour = 0;
        nombreQuillesTombees = new int[NOMBRE_LANCERS];

        // Inscrit la m�thode � l'�v�nement lanc� par d�tecteur quille
        detecteurQuille.quilleTombee += GererQuilleTombee;
    }

    private void OnDestroy()
    {
        // �vite d'appeler la m�thode si l'objet est d�truit
        detecteurQuille.quilleTombee -= GererQuilleTombee;
    }

    // Appel� lorsqu'une quille tombe
    private void GererQuilleTombee(Quille quille)
    {
        quille.EstTombee = true;
        PartirCompteurFinTour();
    }

    public void PartirCompteurFinTour()
    {
        // On r�initialise le temps d'attente pour attendre 4 secondes apr�s que la derni�re quille soit tomb�e
        tempsAttenteEcoule = 0f;

        if (!delaiActif)
        {
            delaiActif = true;
            StartCoroutine("GererDelaiAttente");
        }
    }

    // Coroutine comptant le temps d'attente �coul�
    private IEnumerator GererDelaiAttente()
    {
        while (tempsAttenteEcoule < delaiAttenteQuille)
        {
            tempsAttenteEcoule += Time.deltaTime;
            yield return null;      // Attend la prochaine frame avant de continuer l'ex�cution de la fonction
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

        // R�initialisation des objets
        boule.ReinitialiserPosition();
        joueur.ReinitialiserJoueur();
        FabriqueQuille.Instance.CreerQuilles(releverToutesLesQuilles);

        Debug.Log("Prochain tour " + tour);
    }

    private int CalculerScore()
    {
        int score = 0;

        // On compte s�par�ment le 9e et 10e carreau
        for (int i = 0; i < NOMBRE_CARREAU - 2; i++)
        {
            int quillesCarreau = nombreQuillesTombees[i * 2] + nombreQuillesTombees[i * 2 + 1];
            score += quillesCarreau;

            // Abat ou r�serve
            if (quillesCarreau == FabriqueQuille.NOMBRE_QUILLES)
            {
                int quillesLancerSuivant = nombreQuillesTombees[(i + 1) * 2];
                // R�serve
                score += quillesLancerSuivant;

                // Abat
                if (nombreQuillesTombees[i * 2] == FabriqueQuille.NOMBRE_QUILLES)
                {
                    if (quillesLancerSuivant == FabriqueQuille.NOMBRE_QUILLES)  // Deux abat en ligne
                    {
                        score += nombreQuillesTombees[(i + 2) * 2];  // 2e carreau en avant
                    }
                    else
                    {
                        score += nombreQuillesTombees[((i + 1) * 2) + 1];    // Le 2e lanc� du prochain carreau
                    }
                }
                else // R�serve
                {
                        // Lancer suivant
                }
            }
        }

        //9e carreau
        int avantDernierCarreau = NOMBRE_CARREAU - 2;
        int quillesADCarreau = nombreQuillesTombees[avantDernierCarreau * 2] + nombreQuillesTombees[avantDernierCarreau * 2 + 1];
        if (quillesADCarreau == FabriqueQuille.NOMBRE_QUILLES)
        {
            score += nombreQuillesTombees[(avantDernierCarreau + 1) * 2];

            // Abat
            if (nombreQuillesTombees[avantDernierCarreau * 2] == FabriqueQuille.NOMBRE_QUILLES)
            {
                // Lancer 1 et 2 du 10 carreau peu importe ce qui se passe
                score += nombreQuillesTombees[(avantDernierCarreau + 1) * 2 + 1];  
            }
            
        }

        //10e carreau
        int dernierCarreau = NOMBRE_CARREAU - 1;
        int quillesDernierCarreau = nombreQuillesTombees[dernierCarreau * 2] + nombreQuillesTombees[dernierCarreau * 2 + 1];
        if(quillesDernierCarreau == FabriqueQuille.NOMBRE_QUILLES)
        {
            score += quillesDernierCarreau + nombreQuillesTombees[dernierCarreau * 2 + 2];  // Dernier lancer
        }

        return score;
    }
}
