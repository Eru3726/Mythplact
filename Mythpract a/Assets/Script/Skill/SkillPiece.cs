using UnityEngine;

public class SkillPiece : MonoBehaviour
{
    SkillPieceController skillPieceController;

    int pieceNo;
    bool onSkillPiece;
    private bool OnPiece = false;
    private string PieceName;

    private void Start()
    {
        pieceNo = int.Parse(gameObject.name);
        skillPieceController = transform.parent.GetComponent<SkillPieceController>();
    }
    private void Update()
    {
        Renderer pickupclr = this.GetComponent<SpriteRenderer>();


        // 持ち上げ中は点滅

        if (CursorController.colorchange && gameObject.transform.root.name == "Cursor")
        {

            pickupclr.material.color = new Color(pickupclr.material.color.r, pickupclr.material.color.g, pickupclr.material.color.b, Mathf.Abs(Mathf.Cos(Time.time * 4)));
            pickupclr.sortingOrder = 100;
        }
        else
        {

            pickupclr.material.color = new Color(pickupclr.material.color.r, pickupclr.material.color.g, pickupclr.material.color.b, 1);
            pickupclr.sortingOrder = 10;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.transform.tag == "SkillPiece")
        //{
        //    skillPieceController.Flag[pieceNo - 1] = true;
        //    //Debug.Log("f");
        //}
        if (collision.transform.tag == "SkillBase")
        {
            skillPieceController.Flag[pieceNo - 1] = false;
            //Debug.Log(gameObject.name + "g");
        }
        if (collision.transform.tag == "Cursor")
        {
            skillPieceController.CursorFlag = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.transform.tag == "SkillBase"&&collision.transform.tag != "SkillPiece")
        //{
        //    skillPieceController.Flag[pieceNo - 1] = true;
        //    Debug.Log(gameObject.name + "b");

        //}
        //else if (collision.transform.tag != "SkillBase"&&collision.transform.tag != "Cursor"||collision.transform.tag == "SkillPiece")
        //{
        //    skillPieceController.Flag[pieceNo - 1] = false;
        //    Debug.Log(gameObject.name + "d");
        //}
        if (OnPiece == false)
        {
            if (collision.transform.tag == "SkillBase")
            {
                skillPieceController.Flag[pieceNo - 1] = true;
                Debug.Log(collision.transform.tag + " " + gameObject.name + " b");
            }
            else if (collision.transform.tag != "Cursor" && collision.transform.tag != "SkillPiece")
            {
                skillPieceController.Flag[pieceNo - 1] = false;
                Debug.Log(collision.transform.tag + " " + gameObject.name + " d");
            }
        }
        else
        {
            OnPiece = false;
        }
        if (collision.transform.tag == "SkillPiece")
        {
            skillPieceController.Flag[pieceNo - 1] = false;
            Debug.Log(collision.transform.tag + " " + gameObject.name + " a");
            OnPiece = true;
        }
        else if (collision.transform.tag != "Cursor" && collision.transform.tag != "SkillBase")
        {
            skillPieceController.Flag[pieceNo - 1] = true;
            Debug.Log(collision.transform.tag + " " + gameObject.name + " c");
        }
        if (collision.transform.tag == "Cursor")
        {
            skillPieceController.CursorFlag = true;
            //Debug.Log(gameObject.name + "e");
        }
    }
}
