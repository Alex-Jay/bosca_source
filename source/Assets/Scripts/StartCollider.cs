using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    public StopwatchManager timer;

    void OnTriggerEnter(Collider col)
    {
        timer.ResetTimer();
        timer.ResetRecordedTimer();
    }

    void OnTriggerStay (Collider col)
    {
        timer.StopTimer();
    }

    void OnTriggerExit (Collider col)
    {
        timer.StartTimer();
    }
}
