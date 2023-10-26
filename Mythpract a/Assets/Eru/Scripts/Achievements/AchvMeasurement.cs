using System.Linq;
using UnityEngine;

public class AchvMeasurement : MonoBehaviour
{
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

    public void UseSheriff()
    {
        AchvManager.instance.sheriffUseCount++;
        if (AchvManager.instance.sheriffUseCount >= AchvManager.instance.sheriffClearCount)
        {
            AchvManager.instance.sheriffUseFlg = true;
            //グーリム
        }
    }

    public void GuardNum()
    {
        AchvManager.instance.guardCount++;
        if(AchvManager.instance.guardClearCount <= AchvManager.instance.guardCount)
        {
            AchvManager.instance.guardCountFlg = true;
            //デックス
        }
    }

    public void NoDamageClear()
    {
        AchvManager.instance.noDamage = true;
        //カース
    }

    public void JustGuardNum()
    {
        AchvManager.instance.justGuardCount++;
        if (AchvManager.instance.justGuardCount >= AchvManager.instance.justGuardClearCount)
        {
            AchvManager.instance.justGuardFlg = true;
            //ワイズ
        }
    }

    public void NoGuardClear()
    {
        AchvManager.instance.noGuard = true;
        //ストレングス
    }

    public void ActiveSkillOnlyClear()
    {
        AchvManager.instance.activeSkillOnlyFlg = true;
        //デスピレイションストライク 
    }
}
