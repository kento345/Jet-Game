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
        //�}�E�X�J�[�\�[���̈ʒu����Ray�𔭐�������
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //�h���b�O����Obj�����鎞
        if (selectObject != null)
        {
            //�h���b�O����Obj��EnemyLayer������
            if (((1 << selectObject.gameObject.layer) & EnemyLayer) != 0)
            {
                //�X���C�_�[�̏㏸����
                Slider.Stock();
                Slider.isDragg = true;

                //�}�E�X��Rya��Obj���痣�ꂽ��
                if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != selectObject)
                {
                    //�h���b�O����Obj����
                    selectObject = null;
                    Slider.isDragg=false;
                }
            }
        }
        else if(isPres) 
        {
            //�h���b�O����Ray������������selectObject��null�ɂ���
            Dragg();
            Slider.isDragg = true;
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
                Slider.isDragg = true;
                return;
            }
        }
        //�h���b�O����Obj����
        selectObject = null;
        Slider.isDragg = false;

    }
}
