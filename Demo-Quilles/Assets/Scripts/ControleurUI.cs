using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControleurUI : MonoBehaviour
{
    public TextMeshProUGUI texteQuillesTombees;

    public float dureeAffichageQuillesTombees;

    public TableauScore scores;

    public static ControleurUI Instance { get; private set; }
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

    public void AfficherQuillesTombees(int nombreQuilles)
    {
        texteQuillesTombees.text = "Vous avez fait tombé " + nombreQuilles + " quilles";
        StartCoroutine("AfficherQuillesTombeesCoroutine");
    }

    private IEnumerator AfficherQuillesTombeesCoroutine()
    {
        texteQuillesTombees.gameObject.SetActive(true);
        yield return new WaitForSeconds(dureeAffichageQuillesTombees);
        texteQuillesTombees.gameObject.SetActive(false);
    }
}
