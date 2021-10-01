using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaseScore2Lancers : MonoBehaviour
{
    public TextMeshProUGUI premierLancer;
    public TextMeshProUGUI deuxiemeLancer;
    public TextMeshProUGUI totalCase;

    // Start is called before the first frame update
    protected void Start()
    {
        premierLancer.text = "";
        deuxiemeLancer.text = "";
        totalCase.text = "";

   }

    public void AfficherScore(int premierLancer, int deuxiemeLancer, int totalCase)
    {

        switch (premierLancer)
        {
            case FabriqueQuille.NOMBRE_QUILLES:
                this.premierLancer.text = "X";
                break;
            case 0:
                this.premierLancer.text = "-";
                break;
            default:
                this.premierLancer.text = premierLancer.ToString();
                break;
        }

        this.deuxiemeLancer.text = deuxiemeLancer.ToString();


        this.totalCase.text = totalCase.ToString();
    }
}
