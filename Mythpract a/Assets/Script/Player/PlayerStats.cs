using UnityEngine;

partial class Player
{
    float dmgTime = 0;
    bool onEnemy;
    int MaxHp{ get; set; }



    public void InitHP()   // ゲーム開始時にHPをリセット
    {
        MaxHp = 10;
        GameData.playerNowHp = MaxHp;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Enemy")
        {
            onEnemy = true;
            GameData.playerNowHp -= 1;

        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.tag == "Enemy" && onEnemy)
        {
            dmgTime += Time.deltaTime;
            if(dmgTime > 3)
            {
                GameData.playerNowHp -= 1;

                dmgTime = 0;
            }

        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            dmgTime = 0;
            onEnemy = false;
        }

    }
}