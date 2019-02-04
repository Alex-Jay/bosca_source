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

    void FixedUpdate ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRadius, draggableLayers) )
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
    }
}
