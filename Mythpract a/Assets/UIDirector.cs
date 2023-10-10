using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirector : MonoBehaviour
{
    Player player;
    public Text GameTime;
    private float time = 0;
    public SaveData save;
    void Start()
    {
        GameData.ClearTime = 0;
        GameData.SkillCount = 0;
        GameData.HitCount = 0;
        Debug.Log("タイムリセット");
        time = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GameOver && !GameSceneDirector2.Bossdead2)
        {
            time += Time.deltaTime;

        }
        GameTime.text = time.ToString("F1") + "秒";
        GameData.ClearTime = time;
    }
}
