using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPiece : MonoBehaviour
{
    SkillPieceController skillPieceController;

    int pieceNo;
    bool onSkillPiece;

    private void Start()
    {
        pieceNo = int.Parse(gameObject.name);
        skillPieceController = transform.parent.GetComponent<SkillPieceController>();
    }
    private void Update()
    {
        Renderer pickupclr = this.GetComponent<SpriteRenderer>();


        // éùÇøè„Ç∞íÜÇÕì_ñ≈

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "SkillBase")
        {
            skillPieceController.Flag[pieceNo - 1] = true;
        }
        if (collision.transform.tag == "SkillPiece")
        {
            skillPieceController.Flag[pieceNo - 1] = false;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "SkillBase")
        {
            skillPieceController.Flag[pieceNo - 1] = false;
        }
        if(collision.transform.tag == "SkillPiece")
        {
            skillPieceController.Flag[pieceNo - 1] = true;

        }
    }



}
