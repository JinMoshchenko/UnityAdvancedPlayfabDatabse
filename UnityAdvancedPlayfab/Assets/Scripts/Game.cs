using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject winLogo;

    public TextMeshProUGUI STRENGTH_text;
    public TextMeshProUGUI AGILITY_text;
    public TextMeshProUGUI STAMINA_text;
    public TextMeshProUGUI KNOWLEDGE_text;
    public TextMeshProUGUI ABILITIES_text;

    int STRENGTH=0, AGILITY=0, STAMINA=0, KNOWLEDGE=0, ABILITIES=0;
    const int goalScore = 100;
    float goalScale = 0.7318307f;
    float goalYposition = -0.88f;
    float scaleMultiplier;
    float yPosMultiplier;


    private void Start()
    {
        CalculateMultipliers();
    }

    public void CalculateMultipliers()
    {
        scaleMultiplier = (goalScale - player.localScale.x) / (goalScore * 5);
        yPosMultiplier = (player.position.y - goalYposition) / (goalScore * 5);
    }

    public void STRENGTH_B()
    {
        if(STRENGTH < goalScore)
        {
            STRENGTH += 1;
            STRENGTH_text.SetText("{0}/{1}", STRENGTH, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        if(STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
    public void AGILITY_B()
    {
        if (AGILITY < goalScore)
        {
            AGILITY += 1;
            AGILITY_text.SetText("{0}/{1}", AGILITY, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        if (STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
    public void STAMINA_B()
    {
        if (STAMINA < goalScore)
        {
            STAMINA += 1;
            STAMINA_text.SetText("{0}/{1}", STAMINA, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        if (STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
    public void KNOWLEDGE_B()
    {
        if (KNOWLEDGE < goalScore)
        {
            KNOWLEDGE += 1;
            KNOWLEDGE_text.SetText("{0}/{1}", KNOWLEDGE, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        if (STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
    public void ABILITIES_B()
    {
        if (ABILITIES < goalScore)
        {
            ABILITIES += 1;
            ABILITIES_text.SetText("{0}/{1}", ABILITIES, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        if (STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
}
