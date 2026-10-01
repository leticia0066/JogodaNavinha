using UnityEngine;

public class BossBehaviorAlta2 : StateMachineBehaviour
{
    [Header("Movimento")]
    public float velocidade = 2.5f;

    public float limiteEsquerda = 2f;
    public float limiteDireita = 6f;

    private bool indoDireita = true;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        indoDireita = true;

        Debug.Log("Boss: Alta - Comportamento 2 iniciado!");
    }

    public override void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Transform boss = animator.transform;

        Vector3 posicao = boss.position;

        if (indoDireita)
        {
            posicao.x += velocidade * Time.deltaTime;

            if (posicao.x >= limiteDireita)
            {
                posicao.x = limiteDireita;
                indoDireita = false;
            }
        }
        else
        {
            posicao.x -= velocidade * Time.deltaTime;

            if (posicao.x <= limiteEsquerda)
            {
                posicao.x = limiteEsquerda;
                indoDireita = true;
            }
        }

        boss.position = posicao;
    }

    public override void OnStateExit(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Debug.Log("Boss: Alta - Comportamento 2 terminou!");
    }
}