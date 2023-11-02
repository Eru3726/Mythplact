using UnityEngine;
using UnityEngine.InputSystem;

public class PadCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorCan;

    private bool currentFlg = false;

    [Range(0.0f, 15.0f)]
    public float TimeToHide = 5.0f;

    [SerializeField]
    private RectTransform rectTransform;

    Vector2 previousMousePosition;
    Vector2 currentMousePosition;

    float timeMousePositionStatic = 0.0f;
    void Start()
    {
        Vector3 mp = Input.mousePosition;
        previousMousePosition = currentMousePosition = new Vector2(mp.x, mp.y);
    }

    void Update()
    {
        if (Gamepad.current == null)
        {
            currentFlg = false;
            Cursor.visible = true;
        }
        else
        {
            currentFlg = true;

            Vector3 mp = Input.mousePosition;
            currentMousePosition = new Vector2(mp.x, mp.y);

            if (previousMousePosition == currentMousePosition)
            {
                timeMousePositionStatic += Time.deltaTime;
            }
            else
            {
                timeMousePositionStatic = 0.0f;
            }

            if (timeMousePositionStatic > TimeToHide)
            {
                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;
            }

            previousMousePosition = currentMousePosition;

            rectTransform.transform.position = new Vector2(Mathf.Clamp(rectTransform.transform.position.x, 50, 1920),
                                                           Mathf.Clamp(rectTransform.transform.position.y, 50, 1080));
        }
        cursorCan.SetActive(currentFlg);
    }
}
