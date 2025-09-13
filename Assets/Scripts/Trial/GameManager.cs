using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Canvas canvas;
    private RectTransform canvasRect;
    private Vector2 MousPos;

    private void Start()
    {
        Cursor.visible = false;
        canvas = canvas.GetComponent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        slider = slider.GetComponent<Slider>();
    }

    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out MousPos);

        slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousPos.x, MousPos.y);
    }
}
