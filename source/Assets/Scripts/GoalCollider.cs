using UnityEngine;

public class GoalCollider : MonoBehaviour
{
    public StopwatchManager timer;

    void OnTriggerEnter (Collider col)
    {
        timer.StopTimer();
    }
}
