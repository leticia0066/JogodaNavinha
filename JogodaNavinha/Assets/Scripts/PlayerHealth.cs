using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private int maxVidas = 3;

    private int danosRecebidos;

    [Header("UI das vidas")]
    [SerializeField] private Image[] iconesVida;

    private void Start()
    {
        danosRecebidos = 0;

        AtualizarUI();
    }

    public void ReceberDano()
    {
        danosRecebidos++;

        Debug.Log("Player recebeu dano: " + danosRecebidos);

        AtualizarUI();

        if (danosRecebidos >= 4)
        {
            Morrer();
        }
    }

    private void AtualizarUI()
    {
        if (iconesVida == null)
            return;

        int vidasRestantes = maxVidas - danosRecebidos;

        if (vidasRestantes < 0)
            vidasRestantes = 0;

        for (int i = 0; i < iconesVida.Length; i++)
        {
            if (iconesVida[i] != null)
            {
                iconesVida[i].gameObject.SetActive(i < vidasRestantes);
            }
        }
    }

    private void Morrer()
    {
        Debug.Log("PLAYER MORREU!");

        Time.timeScale = 0f;
    }
}