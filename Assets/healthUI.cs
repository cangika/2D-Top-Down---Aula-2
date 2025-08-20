using UnityEngine;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartsPanel;

    private List<GameObject> hearts = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        // Limpa qualquer cora��o existente
        foreach (Transform child in heartsPanel)
        {
            Destroy(child.gameObject);
        }
        hearts.Clear();

        // Cria os cora��es
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartsPanel);
            hearts.Add(newHeart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}
