using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [Header("バーの上下")]
    [SerializeField] private int bar = 0;        //スライダーの初期値
     
    [SerializeField] private Slider slide;       //スライダー

    [SerializeField] private float speed = 5f;   //スライダーの上昇速度

    private bool isMax = false;                  //スライダーがMaxになったフラグ

    private Player2 player;
    void Start()
    {
        player = GetComponent<Player2>();
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
        if(!isMax　&& player.isDragg)
        {
            bar++;
        }
        //ドラッグしてないときは減算
        if(!player.isDragg && bar != 0) 
        {
            bar--;
        }
        //スライダーの更新
        if (slide != null)
        {
            slide.value = bar;
        }
        //Maxになるとフラグを立てる
        if (bar == 1000)
        {
            isMax = true;
        }
    }
}
