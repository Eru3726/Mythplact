using UnityEngine;

public class AtkNormal : MonoBehaviour
{
    float count = 0;

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
            
            
        }
    }
}
