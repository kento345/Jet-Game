using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("バーの上下")]
    [SerializeField] private int bar = 0;        //スライダーの初期値 
    [SerializeField] private int max = 500;

    [SerializeField] private Slider slide;       //スライダー

    private bool isMax = false;                  //スライダーがMaxになったフラグ

    private RocketShotController Rplayer;
    void Start()
    {
        Rplayer = GetComponent<RocketShotController>();
        //スライダーの初期値を設定
        if (slide != null)
        {
            slide.value = bar;
        }
    }

    void Update()
    {
        //スライダーの動きの補正
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
        //Maxじゃないときまたはドラック中加算
        if(!isMax && Rplayer.isRayhit)
        {
            bar++;
        }
        //ドラッグしてないときは減算
        if(!Rplayer.isRayhit && bar != 0) 
        {
            bar--;
        }
        //スライダーの更新
        if (slide != null)
        {
            slide.value = bar;
        }
        //Maxになるとフラグを立てる
        if (bar == max)
        {
            isMax = true;
        }
    }
}
