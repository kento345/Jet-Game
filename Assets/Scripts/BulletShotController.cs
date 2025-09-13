using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShotController : MonoBehaviour
{
    //-----’eObj,”­ŽËˆÊ’u-----
    [SerializeField] private GameObject bullet;             //’eObj
    [SerializeField] private Transform catapult1;          //”­ŽËˆÊ’u1
    [SerializeField] private Transform catapult2;          //”­ŽËˆÊ’u2

    private float B_speed = 100.0f;
    private bool isPres = false;
    private float timer = 0f;

    Rigidbody b_rb;                                         //’eRigidBody 


    public void OnShot1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPres = true;
            timer = 0f;
        }
        else if (context.canceled)
        {
            isPres = false;
        }
    }

    void Update()
    {
        if (isPres)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Shot();
                timer = 0.1f;
            }
        }
    }

    void Shot()
    {
        Instantiate(bullet, catapult1.position, Quaternion.identity);
        Instantiate(bullet, catapult2.position, Quaternion.identity);
    }

}
