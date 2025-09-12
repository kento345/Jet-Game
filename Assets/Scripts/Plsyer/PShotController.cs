using UnityEngine;
using UnityEngine.InputSystem;

public class PShotController : MonoBehaviour
{
    //-----弾,発射位置Obj-----
    [SerializeField] private GameObject bulletPrefab;     //弾プレファブ
    [SerializeField] private GameObject rocketPrefab;     //ロケットプレファブ

    [SerializeField] private Transform cutapult1;         //発射位置1
    [SerializeField] private Transform cutapult2;         //発射位置2
    [SerializeField] private Transform cutapult3;         //発射位置3

    //-----Ray設定-----
    private GameObject selectObject = null;               //選択中のObj
    private Ray ray;                                      //飛ばすRay
    private RaycastHit hit;                               //Rayが当たった情報

    [SerializeField] private LayerMask EnemyLayer;        //敵Layer
    private SliderScript Slider;                          //スライダー
    public bool isPres = false;                           //ドラッグ中フラグ
    public bool isRayhit = false;                         //Rayが当たったフラグ


    public void OnShot2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPres = true;
            Drag();
        }
        if (context.canceled)
        {
            isPres = false;
            selectObject = null;
            isRayhit = false;
            Instantiate(rocketPrefab, cutapult3.position, cutapult3.transform.rotation);
        }
    }

    void Start()
    {
        Slider = GetComponent<SliderScript>();
    }

    void Update()
    {
        CreatRay();
        //スライダーの処理
        Slider.Stock();

        if (selectObject != null)
        {
            isRayhit = true;
        }
        else
        {
            isRayhit = false;
        }
    }

    void CreatRay()
    {
     

        //クリック中にマウスの位置からRay
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //選択中のObjがある時
        if (selectObject != null)
        {
            //選択中のObjがEnemyLayerか判定
            if (((1 << selectObject.gameObject.layer) & EnemyLayer) != 0)
            {
                //RayがObjに当たっていないとき
                if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != selectObject)
                {
                    //選択Objを解除
                    selectObject = null;
                }
            }
        }
        else if (isPres)
        {
            Drag();
        }
    }
    void Drag()
    {
        //Rayが当たったか判定
        if (Physics.Raycast(ray, out hit))
        {
            //ドラッグ中のObjがEnemyLayerか判定
            if (((1 << hit.collider.gameObject.layer) & EnemyLayer) != 0)
            {
                //ドラッグ中のObjに設定
                selectObject = hit.collider.gameObject;
                return;
            }
        }
        //ドラッグ中のObj解除
        selectObject = null;
    }
}
