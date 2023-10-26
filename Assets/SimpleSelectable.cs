using UnityEngine;

public class SimpleSelectable : MonoBehaviour, ISelectable
{
    public void Deselect()
    {
        Debug.Log(name + " Deselect");
    }

    public void Select()
    {
        Debug.Log(name + " Select");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
