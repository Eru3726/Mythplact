using UnityEngine;

public class SkillBaseController : MonoBehaviour
{
    Collider2D baseCol;
    bool onBase;

    public bool onBaseProp
    {
        get { return onBase; }
        set { onBase = value; }
    }

    private void Start()
    {
        baseCol = gameObject.GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Cursor")
        {
            onBaseProp = true;
        }
    }
}
