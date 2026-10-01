using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Slider barra;
    [SerializeField] private BossController boss;

    private void Start()
    {
        if (barra == null)
        {
            barra = GetComponent<Slider>();
        }

        AtualizarBarra();
    }

    private void Update()
    {
        AtualizarBarra();
    }

    private void AtualizarBarra()
    {
        if (boss == null || barra == null)
            return;

        barra.maxValue = boss.GetVidaMaxima();
        barra.value = boss.GetVidaAtual();
    }
}