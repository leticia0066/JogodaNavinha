using UnityEngine;

public class BossBehaviorBaixa3 : StateMachineBehaviour
{
    [Header("Movimento")]
    public float velocidadeX = 5f;
    public float velocidadeY = 4f;

    public float limiteEsquerda = 2f;
    public float limiteDireita = 6f;
    public float limiteSuperior = 3f;
    public float limiteInferior = -3f;

    private bool indoDireita = true;
    private bool subindo = true;

    public override void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        indoDireita = true;
        subindo = true;

        Debug.Log("Boss: Baixa - Comportamento 3 iniciado!");
    }

    public override void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        Transform boss = animator.transform;

        Vector3 posicao = boss.position;

        // Movimento horizontal
        if (indoDireita)
        {
            posicao.x += velocidadeX * Time.deltaTime;

            if (posicao.x >= limiteDireita)
            {
                posicao.x = limiteDireita;
                indoDireita = false;
            }
        }
        else
        {
            posicao.x -= velocidadeX * Time.deltaTime;

            if (posicao.x <= limiteEsquerda)
            {
                posicao.x = limiteEsquerda;
                indoDireita = true;
            }
        }

        // Movimento vertical
        if (subindo)
        {
            posicao.y += velocidadeY * Time.deltaTime;

            if (posicao.y >= limiteSuperior)
            {
                posicao.y = limiteSuperior;
                subindo = false;
            }
        }
        else
        {
            posicao.y -= velocidadeY * Time.deltaTime;

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
        Debug.Log("Boss: Baixa - Comportamento 3 terminou!");
    }
}