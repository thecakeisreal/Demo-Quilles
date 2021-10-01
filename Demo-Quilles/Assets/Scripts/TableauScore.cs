using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauScore : MonoBehaviour
{
    public const int NB_CASES_REGULIERES = 9;

    private CaseScore2Lancers[] casesRegulieres;
    private CaseScore3Lancers derniereCase;

    public CaseScore2Lancers caseRegulierePrototype;
    public CaseScore3Lancers derniereCasePrototype;

    // Start is called before the first frame update
    void Start()
    {
        casesRegulieres = new CaseScore2Lancers[NB_CASES_REGULIERES];

        for(int i = 0; i < NB_CASES_REGULIERES; i++)
        {
            casesRegulieres[i] = Instantiate(caseRegulierePrototype);
            casesRegulieres[i].transform.SetParent(transform);
        }

        derniereCase = Instantiate(derniereCasePrototype);
        derniereCase.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
