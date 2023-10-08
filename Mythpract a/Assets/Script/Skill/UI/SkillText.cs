using UnityEngine;

public class SkillText : MonoBehaviour
{
    public GameObject skilltext1;
    public GameObject skilltext2;
    public GameObject skilltext3;

    void AllInvalidate()
    {
        skilltext1.SetActive(false);
        skilltext2.SetActive(false);
        skilltext3.SetActive(false);
    }
    public void Skill1Text()
    {
        AllInvalidate();
        skilltext1.SetActive(true);
    }
    public void Skill2Text()
    {
        AllInvalidate();
        skilltext2.SetActive(true);

    }
    public void Skill3Text()
    {
        AllInvalidate();
        skilltext3.SetActive(true);

    }


}
