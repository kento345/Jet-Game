using UnityEngine;
using UnityEngine.InputSystem;

public class RocketShotController : MonoBehaviour
{
    //-----�e,���ˈʒuObj-----
    [SerializeField] private GameObject rocketPrefab;     //���P�b�g�v���t�@�u
    [SerializeField] private Transform cutapult3;         //���ˈʒu

    //-----Ray�ݒ�-----
    private GameObject selectObject = null;               //�I�𒆂�Obj
    private Ray ray;                                      //��΂�Ray
    private RaycastHit hit;                               //Ray�������������

    [SerializeField] private LayerMask EnemyLayer;        //�GLayer
    private SliderScript Slider;                          //�X���C�_�[
    [HideInInspector] public bool isPres = false;                           //�h���b�O���t���O
    [HideInInspector] public bool isRayhit = false;                         //Ray�����������t���O


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
            isRayhit = false;
            selectObject = null;
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
        //�X���C�_�[�̏���
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

    //-----Ray�쐬,�h���b�O���̏���-----
    void CreatRay()
    {
        //�N���b�N���Ƀ}�E�X�̈ʒu����Ray
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //�I�𒆂�Obj�����鎞
        if (selectObject != null)
        {
            //�I�𒆂�Obj��EnemyLayer������
            if (((1 << selectObject.gameObject.layer) & EnemyLayer) != 0)
            {
                //Ray��Obj�ɓ������Ă��Ȃ��Ƃ�
                if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != selectObject)
                {
                    //�I��Obj������
                    selectObject = null;
                }
            }
        }
        else if (isPres)
        {
            Drag();
        }
    }
    //-----Ray�������������̔���
    void Drag()
    {
        //Ray����������������
        if (Physics.Raycast(ray, out hit))
        {
            //�h���b�O����Obj��EnemyLayer������
            if (((1 << hit.collider.gameObject.layer) & EnemyLayer) != 0)
            {
                //�h���b�O����Obj�ɐݒ�
                selectObject = hit.collider.gameObject;
                return;
            }
        }
        //�h���b�O����Obj����
        selectObject = null;
    }
}
