using UnityEngine;

public class CameraRaycastManager : MonoBehaviour
{
    private Camera m_camera;
    [SerializeField] private LayerMask m_layerMask;
    private ISelectable m_currentTarget;

    private void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = m_camera.ViewportPointToRay(new Vector2(.5f, .5f));
        if (Physics.Raycast(ray, out var hit, 50, m_layerMask))
        {
            if (m_currentTarget == null)
            {
                try
                {
                    m_currentTarget = hit.collider.GetComponent<ISelectable>();
                    m_currentTarget.Select();
                }
                catch (System.Exception e)
                {
                    Debug.LogError("No ISelectable Attached");
                }

            }
            else
            {
                try
                {
                    var possibleTarget = hit.collider.GetComponent<ISelectable>();
                    if (possibleTarget != m_currentTarget)
                    {
                        m_currentTarget.Deselect();
                        m_currentTarget = possibleTarget;
                        m_currentTarget.Select();
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning("No ISelectable Attached");
                }

            }
        }
        else
        {
            if (m_currentTarget != null)
            {
                m_currentTarget.Deselect();
                m_currentTarget = null;
            }
        }
    }
}

public interface ISelectable
{
    public void Select();
    public void Deselect();

}
