using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("バーの上下")]
    [SerializeField] private int bar = 0;        //スライダーの初期値
     
    [SerializeField] private Slider slide;       //スライダー

    [SerializeField] private float speed = 5f;   //スライダーの上昇速度

    public bool isDragg = false;                 //ドラッグ中フラグ
    private bool isMax = false;                  //スライダーがMaxになったフラグ

    void Start()
    {
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
            slide.value = Mathf.MoveTowards(slide.value, bar, speed * Time.deltaTime);
        }
    }

    public void Stock()
    {
        //Maxじゃないときまたはドラック中加算
        if(!isMax　&& isDragg)
        {
            bar++;
        }
        //ドラッグしてないときは減算
        else if(!isDragg) 
        {
            bar--;
        }
        //スライダーの更新
        if (slide != null)
        {
            slide.value = bar;
        }
        //Maxになるとフラグを立てる
        if(bar == 1000)
        {
            isMax = true;
            isDragg = true;
        }
    }
}
