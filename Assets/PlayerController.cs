using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private float RoteSpeeed = 5.0f; 
    [SerializeField] private float resetSpeed = 3.0f; 
    [SerializeField] private float speed = 10f;
    private Vector2 inputVer;
    private float Y = 0f;
    private float X = 0f;
    private float max = 60f;
    Rigidbody rb;
    public void OnMove(InputAction.CallbackContext context)
    { 
        inputVer = context.ReadValue<Vector2>();
        /* if (context.performed)
         * {
         * inputVer = context.ReadValue<Vector2>();
         * }
         * if (context.canceled)
         * {
         * inputVer = Vector2.zero;
         * }*/ 
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
            X = -inputVer.x * RoteSpeeed * Time.deltaTime;
            Y = -inputVer.y * RoteSpeeed * Time.deltaTime;

            X = Mathf.Clamp(X, -max,max);
            Y = Mathf.Clamp(Y, -max,max);

            Quaternion qu = Quaternion.identity;
            qu = Quaternion.Euler(Y, 0 , X);
            model.transform.rotation *= qu;
        }
        else
        {
            Quaternion straight = Quaternion.identity;
            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, straight, Time.deltaTime * resetSpeed);
        }
    }

}
