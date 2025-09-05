using UnityEngine;
using UnityEngine.InputSystem;

public class ModelController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;        // �O�i���x
    [SerializeField] private float rotationSpeed = 70f;    // ��]�X�s�[�h
    [SerializeField] private float rollSpeed = 90f;        // ���[���i�X���j�X�s�[�h
    [SerializeField] private float maxRollAngle = 60f;     // �ő�X���p�x

    private Vector2 inputVer; // (x:���E, y:�㉺)
    private float currentRoll = 0f;

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

    void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    void HandleRotation()
    {
        // �㉺�� Pitch
        float pitch = -inputVer.y * rotationSpeed * Time.deltaTime;
        // ���E�� Yaw�i�y�����Ă������j
        float yaw = inputVer.x * rotationSpeed * 0.5f * Time.deltaTime;

        // Roll �͍��E���͂ŌX���i���o�{����⏕�j
        float targetRoll = -inputVer.x * maxRollAngle;
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * 2f);

        Quaternion delta = Quaternion.Euler(pitch, yaw, 0f);
        transform.rotation *= delta;

        // Roll�i�����ڂ��X����j
        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            currentRoll
        );
    }

    void HandleMovement()
    {
        // ��ɑO�i
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
