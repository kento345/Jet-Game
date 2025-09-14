using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShotController : MonoBehaviour
{
    //-----弾Obj,発射位置-----
    [SerializeField] private GameObject bullet;            //弾Obj
    [SerializeField] private Transform catapult1;          //発射位置1
    [SerializeField] private Transform catapult2;          //発射位置2

    private float B_speed = 100.0f;　　　　　　　　　　     //弾の速度
    private bool isPres = false;                           //押されているフラグ
    private float timer = 0f;                              //タイマー
    private float ShotT = 0.1f;                            //発射間隔

    Rigidbody b_rb1;                                        //弾RigidBody1 
    Rigidbody b_rb2;                                        //弾RigidBody2


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
