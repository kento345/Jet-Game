using UnityEngine;
using UnityEngine.InputSystem;

public class PShotController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;     //弾プレファブ
    [SerializeField] private GameObject rocketPrefab;     //ロケットプレファブ

    [SerializeField] private Transform cutapult1;         //発射位置1
    [SerializeField] private Transform cutapult2;         //発射位置2
    [SerializeField] private Transform cutapult3;         //発射位置3

    public void OnShot2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        if (context.canceled)
        {
            Shot2();
        }
    }
   

    void Shot2()
    {
        Instantiate(rocketPrefab, cutapult3.position, cutapult3.transform.rotation);
    }
}
