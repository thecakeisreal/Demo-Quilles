using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaseScore3Lancers : CaseScore2Lancers
{
    public TextMeshProUGUI troisiemeLancer;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        troisiemeLancer.text = "";
    }

    public void AfficherScore(int premierLancer, int deuxiemeLancer, int troisiemeLancer, int totalCase)
    {
        base.AfficherScore(premierLancer, deuxiemeLancer, totalCase);
        this.troisiemeLancer.text = troisiemeLancer.ToString();
    }
}
