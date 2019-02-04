using UnityEngine;
using TMPro;

public class StopwatchManager : MonoBehaviour
{
    public TMP_Text timerLabel;

    [SerializeField]
    private float time;

    /* 
         X = Minutes
         Y = Seconds
         Z = Milliseconds 
    */
    [SerializeField]
    private Vector3 recordedTime = Vector3.zero;

    [SerializeField]
    private bool isStarted = false;

	void Update ()
    {
        if (isStarted)
        {
            time += Time.deltaTime;

            float minutes = time / 60;
            float seconds = time % 60; // Euclidean division for seconds
            float fraction = (time * 100) % 100;

            recordedTime = new Vector3 (minutes, seconds, fraction);
        }

        timerLabel.text = GetTimerText();
    }

    public void StartTimer ()
    {
        isStarted = true;
    }

    public void StopTimer ()
    {
        isStarted = false;
    }

    public void ResetTimer ()
    {
        time = 0;
    }

    public void ResetRecordedTimer ()
    {
        recordedTime = Vector3.zero;
    }

    public string GetTimerText ()
    {
        return string.Format("{0:00} : {1:00} : {2:000}", recordedTime.x, recordedTime.y, recordedTime.z);
    }
}
