using UnityEngine;
using UnityEngine.Pool;

public class PlayerBullet : MonoBehaviour
{
    [Header("Configuração")]
    [SerializeField] private float velocidade = 12f;

    [Header("Dano")]
    [SerializeField] private int dano = 10;

    [Header("Limites")]
    [SerializeField] private float limiteX = 10f;

    private ObjectPool<GameObject> minhaPool;

    public void DefinirPool(ObjectPool<GameObject> pool)
    {
        minhaPool = pool;
    }

    private void Update()
    {
        transform.position += Vector3.right * velocidade * Time.deltaTime;

        if (transform.position.x > limiteX)
        {
            DevolverParaPool();
        }
    }

    public void DevolverParaPool()
    {
        if (minhaPool != null)
        {
            minhaPool.Release(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            BossController boss = other.GetComponent<BossController>();

            if (boss != null)
            {
                boss.ReceberDano(dano);
            }

            DevolverParaPool();
        }
    }
}