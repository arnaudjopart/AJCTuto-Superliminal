using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Vector3 m_movement;
    private Vector2 m_data;

    public void Move(CallbackContext _context)
    {
        m_data = _context.ReadValue<Vector2>().normalized;
    }

    public void Click(CallbackContext _context)
    {
        var screenPosition = _context.ReadValue<Vector2>();
        Debug.Log(screenPosition);
    }

    private void Update()
    {
        //transform.position += m_movement;

        CharacterController controller = GetComponent<CharacterController>();

        m_movement = transform.forward * m_data.y + transform.right * m_data.x;
        m_movement *= m_speed;
        controller.SimpleMove(m_movement);
    }
}
