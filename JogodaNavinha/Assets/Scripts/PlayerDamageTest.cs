using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamageTest : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.hKey.wasPressedThisFrame)
        {
            playerHealth.ReceberDano();
        }
    }
}