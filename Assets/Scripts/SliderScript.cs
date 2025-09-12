using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("�o�[�̏㉺")]
    [SerializeField] private int bar = 0;        //�X���C�_�[�̏����l
     
    [SerializeField] private Slider slide;       //�X���C�_�[

    [SerializeField] private float speed = 5f;   //�X���C�_�[�̏㏸���x

    private bool isMax = false;                  //�X���C�_�[��Max�ɂȂ����t���O

    private Player2 player;
    void Start()
    {
        player = GetComponent<Player2>();
        //�X���C�_�[�̏����l��ݒ�
        if (slide != null)
        {
            slide.value = bar;
        }
    }

    void Update()
    {
        //�X���C�_�[�̓����̕␳
        if (slide != null)
        {
            slide.value = Mathf.MoveTowards(slide.value, bar, speed * Time.deltaTime);
        }
    }

    public void Stock()
    {
        //Max����Ȃ��Ƃ��܂��̓h���b�N�����Z
        if(!isMax�@&& player.isDragg)
        {
            bar++;
        }
        //�h���b�O���ĂȂ��Ƃ��͌��Z
        if(!player.isDragg && bar != 0) 
        {
            bar--;
        }
        //�X���C�_�[�̍X�V
        if (slide != null)
        {
            slide.value = bar;
        }
        //Max�ɂȂ�ƃt���O�𗧂Ă�
        if (bar == 1000)
        {
            isMax = true;
        }
    }
}
