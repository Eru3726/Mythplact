using UnityEngine;

public class SkillPieceController : MonoBehaviour
{
    GameObject[] skillPiece;
    Collider2D[] skillPieceCol;
    GameObject skillBase;
    Collider2D skillBaseCol;
    GameObject cursor;
    int pieceCount;

    bool pieceOutBase;

    bool[] flag;

    public static bool loadPiece = false;

    public bool[] Flag
    {
        get { return flag; }
        set { flag = value; }
    }

    public bool OutBaseProp{
        get { return pieceOutBase; }
        set { pieceOutBase = value;}
    }

    private void Start()
    {
        skillBase = GameObject.Find("Grid/SkillBase1");
        cursor = GameObject.Find("Cursor");

        skillBaseCol = skillBase.GetComponent<Collider2D>();

        pieceCount = this.transform.childCount;

        Flag = new bool[pieceCount];
        skillPiece = new GameObject[pieceCount];
        skillPieceCol = new Collider2D[pieceCount];

    }
    private void Update()
    {

        for(int i = 0; i < pieceCount; ++i)
        {
            if (Flag[i] == true)
            {
                OutBaseProp = false;
            }
            else
            {
                OutBaseProp = true;
                break;
            }
        }
        
        if(gameObject.name == "SkillPiece1(Clone)")
        {
            SkillPieceData.skillPiece1 = gameObject;
        }
        if(gameObject.name == "SkillPiece2(Clone)")
        {
            SkillPieceData.skillPiece2 = gameObject;

        }
        if(gameObject.name == "SkillPiece3(Clone)")
        {
            SkillPieceData.skillPiece3 = gameObject;

        }
    }
}
