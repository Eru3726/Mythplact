using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchvMeasurement : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayerDie()
    {
        AchvManager.instance.dieXCount++;
        if (AchvManager.instance.dieXCount >= AchvManager.instance.dieClearCount)
        {
            AchvManager.instance.dieXFlg = true;
            //サルタリー解放
        }
    }

    public void UseBlink()
    {
        AchvManager.instance.blinkXCount++;
        if (AchvManager.instance.blinkXCount >= AchvManager.instance.blinkClearCount)
        {
            AchvManager.instance.blinkXFlg = true;
            //ストライド解放
        }
    }

    public void DefeatedBoss(int i)
    {
        AchvManager.instance.defeatedBoss[i] = true;
        if (AchvManager.instance.defeatedBoss.All(b => b))
        {
            AchvManager.instance.allBossFlg = true;
            //カース解放
        }
    }

    public void OneHpClear()
    {
        AchvManager.instance.oneHpFlg = true;
        //アドレナリン解放
    }

    public void AttackCombo()
    {
        AchvManager.instance.attackComboFlg = true;
        //ローンウォリアー
    }
}
