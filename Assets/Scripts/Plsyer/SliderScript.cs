using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("�o�[�̏㉺")]
    [SerializeField] private int bar = 0;        //�X���C�_�[�̏����l 
    [SerializeField] private int max = 500;

    [SerializeField] private Slider slide;       //�X���C�_�[

    private bool isMax = false;                  //�X���C�_�[��Max�ɂȂ����t���O

    private RocketShotController Rplayer;
    void Start()
    {
        Rplayer = GetComponent<RocketShotController>();
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
            slide.value = Mathf.Clamp(slide.value, bar, max);
        }
        if(Rplayer.isPres)
        {
            slide.gameObject.SetActive(true);
        }
        else
        {
            slide.gameObject.SetActive(false);
        }
    }

    public void Stock()
    {
        //Max����Ȃ��Ƃ��܂��̓h���b�N�����Z
        if(!isMax && Rplayer.isRayhit)
        {
            bar++;
        }
        //�h���b�O���ĂȂ��Ƃ��͌��Z
        if(!Rplayer.isRayhit && bar != 0) 
        {
            bar--;
        }
        //�X���C�_�[�̍X�V
        if (slide != null)
        {
            slide.value = bar;
        }
        //Max�ɂȂ�ƃt���O�𗧂Ă�
        if (bar == max)
        {
            isMax = true;
        }
    }
}
