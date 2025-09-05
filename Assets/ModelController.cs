using UnityEngine;
using UnityEngine.InputSystem;

public class ModelController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;        // 前進速度
    [SerializeField] private float rotationSpeed = 70f;    // 回転スピード
    [SerializeField] private float rollSpeed = 90f;        // ロール（傾き）スピード
    [SerializeField] private float maxRollAngle = 60f;     // 最大傾き角度

    private Vector2 inputVer; // (x:左右, y:上下)
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
        // 上下で Pitch
        float pitch = -inputVer.y * rotationSpeed * Time.deltaTime;
        // 左右で Yaw（軽くつけてもいい）
        float yaw = inputVer.x * rotationSpeed * 0.5f * Time.deltaTime;

        // Roll は左右入力で傾き（演出＋旋回補助）
        float targetRoll = -inputVer.x * maxRollAngle;
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * 2f);

        Quaternion delta = Quaternion.Euler(pitch, yaw, 0f);
        transform.rotation *= delta;

        // Roll（見た目を傾ける）
        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            currentRoll
        );
    }

    void HandleMovement()
    {
        // 常に前進
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
