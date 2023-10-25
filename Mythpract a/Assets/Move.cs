using UnityEngine;

public class Move : MonoBehaviour
{

    float destroyCount = 0;
    public float speed;
    
    void Update()
    {
        destroyCount += Time.deltaTime;
        if (gameObject.transform.localScale.x > 0)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        }

        if(destroyCount > 5)
        {
            Destroy(gameObject);
        }
    }


}
