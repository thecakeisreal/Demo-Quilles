using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// G�re la logique du jeu et le tour du joueur
public class ControleurJeu : MonoBehaviour
{
    public const int NOMBRE_LANCERS = 21;

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
        // On r�initialise le temps d'attente pour attendre 4 secondes apr�s que la derni�re quille soit tomb�e
        tempsAttenteEcoule = 0f;
        quille.EstTombee = true;

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
}
