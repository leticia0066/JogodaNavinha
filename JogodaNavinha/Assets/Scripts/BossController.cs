using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Vida do Boss")]
    [SerializeField] private int vidaMaxima = 1000;

    private int vidaAtual;

    private void Start()
    {
        vidaAtual = vidaMaxima;

        Debug.Log("Boss iniciou com " + vidaAtual + " de vida.");
    }

    public void ReceberDano(int dano)
    {
        if (vidaAtual <= 0)
            return;

        vidaAtual -= dano;

        if (vidaAtual < 0)
            vidaAtual = 0;

        Debug.Log("Boss recebeu dano! Vida: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        Debug.Log("BOSS DERROTADO!");

        gameObject.SetActive(false);
    }

    public int GetVidaAtual()
    {
        return vidaAtual;
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }
}