using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float currentHoldTimer = 0f;

    [SerializeField]
    private readonly float holdTime = 2f;
	
    void Start ()
    {

    }

	void Update ()
    {
        if (currentHoldTimer >= holdTime)
        {
            // Do box interaction & Reset Timer
            ResetTimer();
        }
    }

    public void IncrementTimer ()
    {
        currentHoldTimer += Time.deltaTime;
    }

    public float GetTimer ()
    {
        return currentHoldTimer;
    }

    public void ResetTimer ()
    {
        currentHoldTimer = 0f;
    }
}
