using UnityEngine;
using UnityEngine.InputSystem;

public class PShotController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;     //�e�v���t�@�u
    [SerializeField] private GameObject rocketPrefab;     //���P�b�g�v���t�@�u

    [SerializeField] private Transform cutapult1;         //���ˈʒu1
    [SerializeField] private Transform cutapult2;         //���ˈʒu2
    [SerializeField] private Transform cutapult3;         //���ˈʒu3

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
