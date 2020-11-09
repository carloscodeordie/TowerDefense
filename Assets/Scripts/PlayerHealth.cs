using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerHitSFX;

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
        PlaySound(playerHitSFX);
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }

    private void PlaySound(AudioClip sound)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
