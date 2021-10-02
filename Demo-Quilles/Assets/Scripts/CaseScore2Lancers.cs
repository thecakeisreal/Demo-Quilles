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

        this.premierLancer.text = premierLancer switch
        {
            FabriqueQuille.NOMBRE_QUILLES => "X",
            0 => "-",
            -1 => "",
            _ => premierLancer.ToString(),
        };

        // On ne peut pas mettre une variable dans un case (seulement une constante)
        if (premierLancer + deuxiemeLancer == FabriqueQuille.NOMBRE_QUILLES && deuxiemeLancer > 0)
        {
            this.deuxiemeLancer.text = "/";
        } 
        else
        {
            this.deuxiemeLancer.text = deuxiemeLancer switch
            {
                0 => "-",
                -1 => "",
                _ => deuxiemeLancer.ToString()
            };
        }

        // On a finit de jouer la case
        this.totalCase.text = (deuxiemeLancer != -1) ? totalCase.ToString() : "";
    }
}
