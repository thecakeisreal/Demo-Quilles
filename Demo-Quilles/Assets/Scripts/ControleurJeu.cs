using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gère la logique du jeu et le tour du joueur
public class ControleurJeu : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
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
        while(tempsAttenteEcoule < delaiAttenteQuille)
        {
            tempsAttenteEcoule += Time.deltaTime;
            yield return null;      // Attend la prochaine frame avant de continuer l'exécution de la fonction
        }

        Debug.Log(detecteurQuille.NbQuillesTombees);
        
        // Réinitialisation des objets
        boule.ReinitialiserPosition();
        FabriqueQuille.Instance.CreerQuilles();
    }
}
