using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    SkillPieceController skillPieceController;

    Transform touchTfm;
    Transform pickupTfm;

    RaycastHit2D hit;

    Vector3 putPos;

    bool pickup;
    bool grabPiece;


    void Start()
    {
        grabPiece = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("grabpiece = " + grabPiece);
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider.tag == "SkillPiece")
        {
            touchTfm = hit.transform;

            skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();

        }
        else if(hit.collider == null)
        {
            touchTfm = null;
        }

        if (touchTfm != null)
        {
            skillPieceController = touchTfm.parent.GetComponent<SkillPieceController>();
            //Debug.Log("outprop" + skillPieceController.OutBaseProp);
            skillPieceController.PieceOnBase();
            if (true/*!skillPieceController.OutBaseProp*/)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // 持ち上げ判定にする
                    pickup = true;
                }
            }
        }

        if (pickup)
        {
            pickupTfm = touchTfm;
            //audioSource.PlayOneShot(SkillSetSE);

            // 掴んでいるときは離す
            if (grabPiece)
            {
                pickupTfm.parent.position = putPos;

                grabPiece = false;
            }
            // 掴む
            else if(!grabPiece)
            {

                grabPiece = true;
            }
            //if (pickupTfm.parent.parent == null)
            //{
            //    pickupTfm.parent.position = gameObject.transform.position + (touchTfm.parent.position - touchTfm.position);
            //    pickupTfm.parent.parent = transform;

            //    CursorController.colorchange = true;
            //    pickupTfm = touchTfm;


            //}
            //else
            //{
            //    pickupTfm.parent.parent = null;

            //    CursorController.colorchange = false;
            //    pickupTfm = touchTfm;


            //}
            pickup = false;
        }

        // つかみ中
        if (grabPiece)
        {
            pickupTfm.parent.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10)); 

        }
        else if(!grabPiece)
        {

        }


        if (hit.collider.tag == "SkillBase" )
        {
            int skillBaseNum = 19;
            for(int i = 0; i< skillBaseNum; i++)
            {
                if(hit.collider.name == i.ToString())
                {
                    Debug.Log(hit.collider.transform.position);
                    putPos = hit.collider.transform.position;
                }
            }
        }
    }
}
