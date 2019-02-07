using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    public int interactionRadius = 5;

    public Color lineColor;
    
    [Range(0f, .2f)]
    public float lineWidth = .05f; 

    public LayerMask draggableLayers;

    void Start ()
    {
        // Do init
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
        }
    }
}
