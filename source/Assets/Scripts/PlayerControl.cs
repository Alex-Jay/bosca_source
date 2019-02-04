using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerSpawnPoint;

    public void Die ()
    {
        // Reset player position
        gameObject.transform.position = playerSpawnPoint.transform.position;
    }
}
