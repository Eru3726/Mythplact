using UnityEngine;

public class FadeManage : MonoBehaviour
{
    public bool fadeInFlag=false;
    public bool fadeOutFlag = false;
    
    [SerializeField] int Inspeed;
    [SerializeField] float Outspeed;
    [SerializeField] Color color; //初期の色

    public GameObject fadeInPlate;
    public GameObject fadeOutPlate;

    Vector2 Intra;
    Color Outcolor;
    void Start()
    {
        Intra = fadeInPlate.transform.position;
        color.a = 0;
        fadeOutPlate.GetComponent<Renderer>().material.color = color;
        Outcolor = fadeOutPlate.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(color.a);
        Debug.Log(Outcolor);
        FadeIn();
        FadeOut();
    }
    void FadeIn()
    {
        if (fadeInFlag)
        {
           
            Vector3 train= fadeInPlate.transform.position;
            train.x -= Inspeed;
            fadeInPlate.transform.position = train;
            
        }
        else { fadeInPlate.transform.position = Intra; }
    }
    void FadeOut()
    {
        if (fadeOutFlag)
        {
            Outcolor.a += Outspeed;
            fadeOutPlate.GetComponent<Renderer>().material.color=Outcolor;
        }
        else
        {
            fadeOutPlate.GetComponent<Renderer>().material.color=color;
            Outcolor = fadeOutPlate.GetComponent<Renderer>().material.color;
        }
    }
}
