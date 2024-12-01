using UnityEngine;

public class ShowInEditorOnly : MonoBehaviour
{
    private MeshRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
        DisableRenderer();
    }

    /// <summary>
    /// Disable mesh renderer.
    /// </summary>
    private void DisableRenderer()
    {
        renderer.enabled = false;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init()
    {
        renderer = GetComponent<MeshRenderer>();
    }
}
