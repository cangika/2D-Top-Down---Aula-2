// ItemControl.cs
using UnityEngine;
using TMPro;

public class ItemControl : MonoBehaviour
{
    [Header("Player Stats")]
    public int coins;

    [Header("Health Settings")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("UI Settings")]
    public TMP_Text coinText;
    public HealthUI healthUI; // referência ao script novo

    [Header("Layers")]
    public LayerMask coinLayer;
    public LayerMask enemyLayer;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthUI.Setup(maxHealth); // cria os corações
        UpdateUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            if (audioSource != null) audioSource.Play();
            Destroy(other.gameObject);
            UpdateUI();
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        healthUI.UpdateHearts(currentHealth); // atualiza na UI
        Debug.Log("Vida Atual: " + currentHealth);
    }

    void UpdateUI()
    {
        if (coinText != null) coinText.text = "Moedas: " + coins.ToString();
    }
}
