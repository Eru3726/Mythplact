using UnityEngine;

public class SkillPieceDisplay : MonoBehaviour
{
    public GameObject skillpiece1;
    public GameObject skillpiece2;
    public GameObject skillpiece3;
    void AllInvalidate()
    {
        skillpiece1.SetActive(false);
        skillpiece2.SetActive(false);
        skillpiece3.SetActive(false);
    }

    public void Skill1Select()
    {
        AllInvalidate();
        skillpiece1.SetActive(true);
    }
    public void Skill2Select()
    {
        AllInvalidate();
        skillpiece2.SetActive(true);
    }
    public void Skill3Select()
    {
        AllInvalidate();
        skillpiece3.SetActive(true);
    }

}
