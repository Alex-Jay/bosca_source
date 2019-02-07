using UnityEngine;
using UnityEngine.UI;

public class ObjectDragger : MonoBehaviour
{
    public int interactionRadius = 5;

    public Color lineColor;
    
    [Range(0f, .2f)]
    public float lineWidth = .05f; 

    public LayerMask draggableLayers;

    [SerializeField]
    private Image progressBar;

    void Start ()
    {
        // Do init
        progressBar = GameObject.Find("ProgressBar").GetComponent<Image>();
    }

    void Update ()
    {
        UpdateOutlineFromRaycast();
    }

    void UpdateOutlineFromRaycast ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Enable outline if ray hits
        if (Physics.Raycast(ray, out hit, interactionRadius, draggableLayers))
        {
            hit.collider.gameObject.GetComponent<Highlightable>().isHighlighted = true;
            CheckUserInput(hit);
        }
    }

    void CheckUserInput (RaycastHit hit)
    {
        Interactable _interactable = hit.collider.GetComponent<Interactable>();

        // If mouse is held down and end time is not reached
        if (Input.GetMouseButton (0))
        {

            _interactable.IncrementTimer();
        }
        else
        {
            _interactable.ResetTimer();
        }

        progressBar.fillAmount = _interactable.GetTimer() / 2f;
    }
}
