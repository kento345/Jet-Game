using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    //-----Dragg-----
    private GameObject selectObject = null;    //�h���b�O����Obj
    private Ray ray;                           //Ray
    RaycastHit hit;                            //Ray�������������̏��

    [SerializeField] private LayerMask EnemyLayer;  //�GLayer
    private SliderScript Slider;          //�X���C�_�[
    private bool isPres = false;
    public bool isDragg = false;                 //�h���b�O���t���O


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
            isDragg = false;
        }
    }

    void Start()
    {
        Slider = GetComponent<SliderScript>();
    }

    void Update()
    {
        Shot();
        //�X���C�_�[�̏㏸����
        Slider.Stock();

        if (selectObject != null)
        {
            isDragg = true ;
        }
        else 
        {
            isDragg = false;
        }
    }

    void Shot()
    {
        //�}�E�X�J�[�\�[���̈ʒu����Ray�𔭐�������
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //�h���b�O����Obj�����鎞
        if (selectObject != null)
        {
            //�h���b�O����Obj��EnemyLayer������
            if (((1 << selectObject.gameObject.layer) & EnemyLayer) != 0)
            {
                //�}�E�X��Rya��Obj���痣�ꂽ��
                if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != selectObject)
                {
                    //�h���b�O����Obj����
                    selectObject = null;
                }
            }
        }
        else if(isPres) 
        {
            //�h���b�O����Ray������������selectObject��null�ɂ���
            Dragg();
        }
    }

    void Dragg()
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
