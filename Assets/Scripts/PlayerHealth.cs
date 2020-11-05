using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        UpdateHealthText();
    }

    private void OnTriggerEnter(Collider other)
    {
        DecreaseEnergy();
    }

    private void DecreaseEnergy()
    {
        playerHealth -= healthDecrease;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }
}
