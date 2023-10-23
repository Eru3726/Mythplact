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

        if(gameObject.name == "SkillPiece10(Clone)")
        {
            SkillPieceData.skillPiece10 = gameObject;
        }

        if (gameObject.name == "SkillPiece11(Clone)")
        {
            SkillPieceData.skillPiece11 = gameObject;
        }
        if (gameObject.name == "SkillPiece12(Clone)")
        {
            SkillPieceData.skillPiece12 = gameObject;
        }
        if (gameObject.name == "SkillPiece13(Clone)")
        {
            SkillPieceData.skillPiece13 = gameObject;
        }
        if (gameObject.name == "SkillPiece14(Clone)")
        {
            SkillPieceData.skillPiece14 = gameObject;
        }
        if (gameObject.name == "SkillPiece15(Clone)")
        {
            SkillPieceData.skillPiece15 = gameObject;
        }
        if (gameObject.name == "SkillPiece16(Clone)")
        {
            SkillPieceData.skillPiece16 = gameObject;
        }
        if (gameObject.name == "SkillPiece17(Clone)")
        {
            SkillPieceData.skillPiece17 = gameObject;
        }
        if (gameObject.name == "SkillPiece18(Clone)")
        {
            SkillPieceData.skillPiece18 = gameObject;
        }
        if (gameObject.name == "SkillPiece19(Clone)")
        {
            SkillPieceData.skillPiece19 = gameObject;
        }


    }
}
