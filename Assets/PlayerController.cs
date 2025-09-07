using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private float RoteSpeeed = 5.0f;
    [SerializeField] private float resetSpeed = 3.0f;
    [SerializeField] private float speed = 10f;
    private Vector2 inputVer;

    Rigidbody rb;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputVer = context.ReadValue<Vector2>();
        }
        if (context.canceled)
        {
            inputVer = Vector2.zero;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + model.transform.forward * speed * Time.deltaTime);
    }

    void Move()
    {
       
        if (inputVer != Vector2.zero)
        {
            Quaternion qu = Quaternion.identity;

            qu = Quaternion.Euler(-inputVer.y, 0, -inputVer.x);

            model.transform.rotation *= qu;
        }
        else
        {
            Quaternion straight = Quaternion.identity;

            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, straight, Time.deltaTime * resetSpeed);
        }

    }
}
