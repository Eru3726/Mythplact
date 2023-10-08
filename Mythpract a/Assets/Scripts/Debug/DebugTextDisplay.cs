using UnityEngine;
using UnityEngine.UI;

public class DebugTextDisplay : MonoBehaviour
{
    public Text i;
    public Text f;
    public Text s;
    public Text b;
    public Text sf;
    public Text d;

    void Update()
    {
        i.text = "Int:" + GameData.testInt.ToString();
        f.text = "Float:" + GameData.testFloat.ToString("0.0");
        s.text = "String:" + GameData.testString.ToString();
        b.text = "Bool:" + GameData.testBool.ToString();
        sf.text = "File:" + DataManager.saveFile.ToString();

        if (DataManager.saveData)
        {
            d.text = "データあり".ToString();
        }
        else
        {
            d.text = "データなし".ToString();
        }
    }
}
