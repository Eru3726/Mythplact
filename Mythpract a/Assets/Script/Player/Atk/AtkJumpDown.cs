using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkJumpDown : MonoBehaviour
{
    bool hitAtkJumpDown = false;
    float count = 0;
    public bool HitAtkJumpDown { get { return hitAtkJumpDown; } set { hitAtkJumpDown = value; } }

    private void Update()
    {
        count += Time.deltaTime;


    }
    private void OnTriggerStay2D(Collider2D col)
    {

        int layer = col.gameObject.layer;
        Player player = transform.root.gameObject.GetComponent<Player>();
        SY.HitMng atkMng = col.transform.root.gameObject.GetComponent<SY.HitMng>();

        if (layer == LayerMask.NameToLayer("Hit") && 0.3f <= count)
        {
            player.HitEffect(gameObject);
            count = 0;
            HitAtkJumpDown = true;

        }
    }
}
