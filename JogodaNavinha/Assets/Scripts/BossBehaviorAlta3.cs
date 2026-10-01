using UnityEngine;

public class BossBehaviorAlta3 : StateMachineBehaviour
{
    [Header("Movimento")]
    public float velocidade = 1.5f;
    public float limiteSuperior = 2.5f;
    public float limiteInferior = -2.5f;

    private bool subindo = true;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        subindo = true;

        Debug.Log("Boss: Alta - Comportamento 3 iniciado!");
    }

    public override void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Transform boss = animator.transform;

        Vector3 posicao = boss.position;

        if (subindo)
        {
            posicao.y += velocidade * Time.deltaTime;

            if (posicao.y >= limiteSuperior)
            {
                posicao.y = limiteSuperior;
                subindo = false;
            }
        }
        else
        {
            posicao.y -= velocidade * Time.deltaTime;

            if (posicao.y <= limiteInferior)
            {
                posicao.y = limiteInferior;
                subindo = true;
            }
        }

        boss.position = posicao;
    }

    public override void OnStateExit(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Debug.Log("Boss: Alta - Comportamento 3 terminou!");
    }
}