using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Gère l'affichage du tableau des scores
public class TableauScore : MonoBehaviour
{
    public const int NB_CASES_REGULIERES = 9;

    // Instances des cases
    private CaseScore2Lancers[] casesRegulieres;
    private CaseScore3Lancers derniereCase;

    // Prototypes
    public CaseScore2Lancers caseRegulierePrototype;
    public CaseScore3Lancers derniereCasePrototype;

    // Start is called before the first frame update
    void Start()
    {
        casesRegulieres = new CaseScore2Lancers[NB_CASES_REGULIERES];

        for(int i = 0; i < NB_CASES_REGULIERES; i++)
        {
            CaseScore2Lancers case2Lancers = Instantiate(caseRegulierePrototype);
            case2Lancers.transform.SetParent(transform);
            casesRegulieres[i] = case2Lancers;
        }

        derniereCase = Instantiate(derniereCasePrototype);
        derniereCase.transform.SetParent(transform);

        
    }
}
