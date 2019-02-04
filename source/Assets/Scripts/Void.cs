using UnityEngine;

public class Void : MonoBehaviour
{
    private GameObject player;

    void Awake ()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter ()
    {
        player.GetComponent<PlayerControl>().Die();
    }
}
