using UnityEngine;
using UnityEngine.InputSystem;

public class PMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed     = 50f;        // �O�i���x
    [SerializeField] private float rotationSpeed = 70f;    // ��]�X�s�[�h
    [SerializeField] private float rollSpeed     = 6f;        // ���[���i�X���j�X�s�[�h
    [SerializeField] private float maxRollAngle  = 60f;     // �ő�X���p�x
    [SerializeField] private float maxPitch      = 80f;
    [SerializeField] private Transform visualRoot;

  
    private Vector2 inputVer; // (x:���E, y:�㉺)
    private float currentRoll = 0f;
    private float Y = 0f;
    private float X = 0f;

    Rigidbody rb;

    public void OnMove(InputAction.CallbackContext context)
    {
            inputVer = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Vector3 move = transform.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);

        Quaternion targetRote = Quaternion.Euler(Y, X, 0f);
        rb.MoveRotation(targetRote);
    }

    void Move()
    {
        float dt = Time.deltaTime;

        X += inputVer.x * rotationSpeed * dt;
        Y += -inputVer.y * rotationSpeed * dt;
        Y  = Mathf.Clamp(Y, -maxPitch, maxPitch);

        transform.rotation = Quaternion.Euler(Y,X,0f);
       

        // Roll �͍��E���͂ŌX���i���o�{����⏕�j
        float targetRoll = -inputVer.x * maxRollAngle;
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, rollSpeed * dt);

        if (visualRoot != null)
        {
            Quaternion targetVisu = Quaternion.Euler(0f, 0f,currentRoll);

            visualRoot.localRotation = Quaternion.Slerp(visualRoot.localRotation,targetVisu,rollSpeed * dt);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Y,X,currentRoll);
        }
    }
}
