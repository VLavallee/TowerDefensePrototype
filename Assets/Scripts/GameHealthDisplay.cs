using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHealthDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    TextMeshProUGUI gameHealthText;
    float lives;
    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        gameHealthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        gameHealthText.text = lives.ToString();
    }
    public void DecreaseGameHealth(int amount)
    {
        if (lives >= amount)
        {
            lives -= amount;
            UpdateDisplay();
        }
        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
