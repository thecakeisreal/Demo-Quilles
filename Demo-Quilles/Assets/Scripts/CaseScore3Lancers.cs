using TMPro;

// G�re l'affichage pour une case � 3 lancers. Se base sur une case � 2 lancers
public class CaseScore3Lancers : CaseScore2Lancers
{
    // R�f�rence pour le texte du 3e lancer
    public TextMeshProUGUI troisiemeLancer;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        troisiemeLancer.text = "";
    }

    // Affiche le score pour la case comportant 3 lancers
    public void AfficherScore(int premierLancer, int deuxiemeLancer, int troisiemeLancer, int totalCase)
    {
        base.AfficherScore(premierLancer, deuxiemeLancer, totalCase);
        this.troisiemeLancer.text = troisiemeLancer switch
        {
            FabriqueQuille.NOMBRE_QUILLES => "X",
            0 => "-",
            -1 => "",
            _ => troisiemeLancer.ToString()
        };
    }
}
