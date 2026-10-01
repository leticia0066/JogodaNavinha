using UnityEngine;

public class BossBehaviorMedia1 : StateMachineBehaviour
{
    [Header("Movimento")]
    public float velocidade = 3.5f;
    public float limiteSuperior = 3f;
    public float limiteInferior = -3f;

    private bool subindo = true;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        subindo = true;

        Debug.Log("Boss: Media - Comportamento 1 iniciado!");
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
        Debug.Log("Boss: Media - Comportamento 1 terminou!");
    }
}