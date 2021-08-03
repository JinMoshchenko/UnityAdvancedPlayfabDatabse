﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Character
{
    public int _STRENGTH, _AGILITY, _STAMINA, _KNOWLEDGE, _ABILITIES;

    public Character(int _STRENGTH, int _AGILITY, int _STAMINA, int _KNOWLEDGE, int _ABILITIES)
    {
        this._STRENGTH = _STRENGTH;
        this._AGILITY = _AGILITY;
        this._STAMINA = _STAMINA;
        this._KNOWLEDGE = _KNOWLEDGE;
        this._ABILITIES = _ABILITIES;
    }
}

public class Game : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject winLogo;

    #region Public fields
    public TextMeshProUGUI STRENGTH_text;
    public TextMeshProUGUI AGILITY_text;
    public TextMeshProUGUI STAMINA_text;
    public TextMeshProUGUI KNOWLEDGE_text;
    public TextMeshProUGUI ABILITIES_text;
    public PlayfabManager playfabManager;
    [HideInInspector]public int STRENGTH, AGILITY, STAMINA, KNOWLEDGE, ABILITIES;
    #endregion

    #region Private fields
    const int goalScore = 100;
    float goalScale = 0.7318307f;
    float goalYposition = -0.88f;
    float scaleMultiplier;
    float yPosMultiplier;
    #endregion


    private void Start()
    {
        CalculateMultipliers();
    }

    public Character ReturnClass()
    {
        return new Character(STRENGTH, AGILITY, STAMINA, KNOWLEDGE, ABILITIES);
    }
    public void CalculateMultipliers()
    {
        scaleMultiplier = (goalScale - player.localScale.x) / (goalScore * 5);
        yPosMultiplier = (player.position.y - goalYposition) / (goalScore * 5);
    }
    public void GameCompleted()
    {
        if (STRENGTH == goalScore && AGILITY == goalScore && STAMINA == goalScore && KNOWLEDGE == goalScore && ABILITIES == goalScore)
        {
            logo.SetActive(false);
            winLogo.SetActive(true);
        }
    }
    public void SetUIValues(Character character)
    {
        STRENGTH_text.SetText("{0}/{1}", character._STRENGTH, goalScore);
        AGILITY_text.SetText("{0}/{1}", character._AGILITY, goalScore);
        STAMINA_text.SetText("{0}/{1}", character._STAMINA, goalScore);
        KNOWLEDGE_text.SetText("{0}/{1}", character._KNOWLEDGE, goalScore);
        ABILITIES_text.SetText("{0}/{1}", character._ABILITIES, goalScore);
    }

    #region Buttons
    public void STRENGTH_B()
    {
        if(STRENGTH < goalScore)
        {
            STRENGTH += 1;
            STRENGTH_text.SetText("{0}/{1}", STRENGTH, goalScore);
            player.localScale = new Vector3(player.localScale.x + scaleMultiplier, player.localScale.y + scaleMultiplier, player.localScale.z + scaleMultiplier);
            player.position = new Vector3(player.position.x, player.position.y - yPosMultiplier, player.position.y);
        }
        GameCompleted();
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
        GameCompleted();
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
        GameCompleted();
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
        GameCompleted();
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
        GameCompleted();
    }
    public void BACK_B()
    {
        SceneManager.LoadScene(0);
    }
    public void SAVE_B()
    {
        playfabManager.SaveCharacterStats();
    }
    #endregion
}
