using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShotController : MonoBehaviour
{
    //-----�eObj,���ˈʒu-----
    [SerializeField] private GameObject bullet;            //�eObj
    [SerializeField] private Transform catapult1;          //���ˈʒu1
    [SerializeField] private Transform catapult2;          //���ˈʒu2

    private float B_speed = 100.0f;�@�@�@�@�@�@�@�@�@�@     //�e�̑��x
    private bool isPres = false;                           //������Ă���t���O
    private float timer = 0f;                              //�^�C�}�[
    private float ShotT = 0.1f;                            //���ˊԊu

    Rigidbody b_rb1;                                        //�eRigidBody1 
    Rigidbody b_rb2;                                        //�eRigidBody2


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
                timer = ShotT;
            }
        }
    }

    void Shot()
    {
       var bullet1 = Instantiate(bullet, catapult1.position, Quaternion.identity);
       var bullet2 = Instantiate(bullet, catapult2.position, Quaternion.identity);

        b_rb1 = bullet1.GetComponent<Rigidbody>();
        b_rb2 = bullet2.GetComponent<Rigidbody>();

        b_rb1.AddForce(transform.forward * B_speed /**  Time.deltaTime*/ ,ForceMode.Impulse);
        b_rb2.AddForce(transform.forward * B_speed /**  Time.deltaTime */,ForceMode.Impulse);
    }

}
