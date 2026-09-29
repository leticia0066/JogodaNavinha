using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float velocidade = 7f;

    [Header("Limites da tela")]
    [SerializeField] private float limiteXMin = -7f;
    [SerializeField] private float limiteXMax = 0f;
    [SerializeField] private float limiteYMin = -4f;
    [SerializeField] private float limiteYMax = 4f;

    [Header("Tiro")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float intervaloTiro = 0.25f;
    [SerializeField] private int tamanhoInicialPool = 10;
    [SerializeField] private int tamanhoMaximoPool = 30;

    private ObjectPool<GameObject> bulletPool;

    private float tempoUltimoTiro;

    private void Awake()
    {
        bulletPool = new ObjectPool<GameObject>(
            CriarBala,
            AtivarBala,
            DesativarBala,
            DestruirBala,
            true,
            tamanhoInicialPool,
            tamanhoMaximoPool
        );
    }

    private void Update()
    {
        Mover();

        Atirar();
    }

    private void Mover()
    {
        Vector2 movimentoInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            movimentoInput.x = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoInput.x -= Keyboard.current.aKey.isPressed ? 1f : 0f;

            movimentoInput.y = Keyboard.current.wKey.isPressed ? 1f : 0f;
            movimentoInput.y -= Keyboard.current.sKey.isPressed ? 1f : 0f;
        }

        Vector3 movimento = new Vector3(
            movimentoInput.x,
            movimentoInput.y,
            0f
        );

        transform.position += movimento * velocidade * Time.deltaTime;

        Vector3 posicao = transform.position;

        posicao.x = Mathf.Clamp(posicao.x, limiteXMin, limiteXMax);
        posicao.y = Mathf.Clamp(posicao.y, limiteYMin, limiteYMax);

        transform.position = posicao;
    }

    private void Atirar()
    {
        if (Keyboard.current == null)
            return;

        if (!Keyboard.current.spaceKey.isPressed)
            return;

        if (Time.time < tempoUltimoTiro + intervaloTiro)
            return;

        tempoUltimoTiro = Time.time;

        GameObject bala = bulletPool.Get();

        bala.transform.position = firePoint.position;
        bala.transform.rotation = firePoint.rotation;

        PlayerBullet scriptBala = bala.GetComponent<PlayerBullet>();

        if (scriptBala != null)
        {
            scriptBala.DefinirPool(bulletPool);
        }
    }

    private GameObject CriarBala()
    {
        GameObject bala = Instantiate(bulletPrefab);

        return bala;
    }

    private void AtivarBala(GameObject bala)
    {
        bala.SetActive(true);
    }

    private void DesativarBala(GameObject bala)
    {
        bala.SetActive(false);
    }

    private void DestruirBala(GameObject bala)
    {
        Destroy(bala);
    }
}