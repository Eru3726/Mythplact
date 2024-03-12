using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeManager : MonoBehaviour
{
    public GameObject FadeinPanel;
    public GameObject FadeoutPanel;
    public RectTransform FadeOutPanel;
    public RectTransform FadeInPanel;
    private bool Fadeouts = false;
    private bool Fadeins = false;
    public Button button;
    public float FadeSpeed = 7000;
    public float Fadeoutpos = -2800;
    public float Fadeinpos = -4800;
    // Start is called before the first frame update
    void Start()
    {
        Fadeins = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fadeouts == true)
        {
            FadeOutPanel.anchoredPosition = Vector3.MoveTowards(FadeOutPanel.anchoredPosition, new Vector3(Fadeoutpos, 0, 0), Time.deltaTime * FadeSpeed);
        }
        if (FadeOutPanel.anchoredPosition.x == Fadeoutpos)
        {
            button.GetComponent<Button>().onClick.Invoke();
        }

        if (Fadeins == true)
        {
            FadeInPanel.anchoredPosition = Vector3.MoveTowards(FadeInPanel.anchoredPosition, new Vector3(Fadeinpos, 0, 0), Time.deltaTime * FadeSpeed);
        }
    }

    public void Fadeout()
    {
        Fadeouts = true;
    }

    public void Fadein()
    {
        Fadeins = true;
    }

    public void skilltutorial()
    {
        SceneManager.LoadScene("SkillPieceTutorial");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Restscene");
    }
}
