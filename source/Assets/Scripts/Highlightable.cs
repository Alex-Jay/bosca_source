using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public bool isHighlighted = false;

    public float outlineWidth = 6f;

    public Color outlineColor = new Color(102f, 255f, 0f, 255f);

    private Outline _outline;

    void Awake ()
    {
        _outline = gameObject.AddComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
        _outline.OutlineWidth = outlineWidth;
        _outline.OutlineColor = outlineColor;
        _outline.enabled = false;
    }

    void Update ()
    {
        if (isHighlighted)
            _outline.enabled = true;
        else
            _outline.enabled = false;
    }

    void LateUpdate ()
    {
        isHighlighted = false;
    }
}
