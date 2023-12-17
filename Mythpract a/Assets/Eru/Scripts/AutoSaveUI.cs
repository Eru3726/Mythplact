using UnityEngine;
using UnityEngine.UI;

public class AutoSaveUI : MonoBehaviour
{
    public static AutoSaveUI instance;

    public bool nowSaveFlg = false;

    [SerializeField]
    private GameObject can;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private RectTransform circle;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private float time = 3;

    private float timer = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        can.SetActive(false);
    }

    void Update()
    {
        if (!nowSaveFlg) return;
        if (timer < 0) AutoSaveUIClause();
        else
        {
            timer -= Time.deltaTime;
            circle.transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
        }
    }

    public void AutoSaveUIOpen()
    {
        can.SetActive(true);
        nowSaveFlg = true;
        timer = time;
    }

    public void AutoSaveUIClause()
    {
        can.SetActive(false);
        nowSaveFlg = false;
    }
}
