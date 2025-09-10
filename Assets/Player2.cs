using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    //-----Dragg-----
    private GameObject selectObject = null;    //ドラッグ中のObj
    private Ray ray;                           //Ray
    RaycastHit hit;                            //Rayが当たった時の情報

    [SerializeField] private LayerMask EnemyLayer;  //敵Layer
    private SliderScript Slider;          //スライダー
    private bool isPres = false;
    

    public void OnShot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPres = true;
            Dragg();
        }
        if (context.canceled)
        {
            isPres=false;
            selectObject = null;
        }
    }

    void Start()
    {
        Slider = GetComponent<SliderScript>();
    }

    void Update()
    {
        Shot();
    }

    void Shot()
    {
        //マウスカーソールの位置からRayを発生させる
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //ドラッグ中のObjがある時
        if (selectObject != null)
        {
            //ドラッグ中のObjがEnemyLayerか判定
            if (((1 << selectObject.gameObject.layer) & EnemyLayer) != 0)
            {
                //スライダーの上昇処理
                Slider.Stock();
                Slider.isDragg = true;

                //マウスのRyaがObjから離れたら
                if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != selectObject)
                {
                    //ドラッグ中のObj解除
                    selectObject = null;
                    Slider.isDragg=false;
                }
            }
        }
        else if(isPres) 
        {
            //ドラッグ中にRayが当たったらselectObjectをnullにする
            Dragg();
            Slider.isDragg = true;
        }
    }

    void Dragg()
    {
        //Rayが当たったか判定
        if (Physics.Raycast(ray, out hit))
        {
            //ドラッグ中のObjがEnemyLayerか判定
            if (((1 << hit.collider.gameObject.layer) & EnemyLayer) != 0)
            {
                //ドラッグ中のObjに設定
                selectObject = hit.collider.gameObject;
                Slider.isDragg = true;
                return;
            }
        }
        //ドラッグ中のObj解除
        selectObject = null;
        Slider.isDragg = false;

    }
}
