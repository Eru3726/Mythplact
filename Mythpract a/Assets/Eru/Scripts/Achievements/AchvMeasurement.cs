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
            AchvManager.instance.clearAchv++;
            //サルタリー解放
        }
    }

    public void UseBlink()
    {
        AchvManager.instance.blinkXCount++;
        if (AchvManager.instance.blinkXCount >= AchvManager.instance.blinkClearCount)
        {
            AchvManager.instance.blinkXFlg = true;
            AchvManager.instance.clearAchv++;
            //ストライド解放
        }
    }

    public void DefeatedBoss(int i)
    {
        if (AchvManager.instance.defeatedBoss[i] == false)
        {
            AchvManager.instance.defeatedBoss[i] = true;
            AchvManager.instance.clearBoss++;
        }
        if (AchvManager.instance.defeatedBoss.All(b => b))
        {
            AchvManager.instance.allBossFlg = true;
            AchvManager.instance.clearAchv++;
            //カース解放
        }
    }

    public void OneHpClear()
    {
        AchvManager.instance.oneHpFlg = true;
        AchvManager.instance.clearAchv++;
        //アドレナリン解放
    }

    public void AttackCombo()
    {
        AchvManager.instance.attackComboFlg = true;
        AchvManager.instance.clearAchv++;
        //ローンウォリアー
    }

    public void UseSheriff()
    {
        AchvManager.instance.sheriffUseCount++;
        if (AchvManager.instance.sheriffUseCount >= AchvManager.instance.sheriffClearCount)
        {
            AchvManager.instance.sheriffUseFlg = true;
            AchvManager.instance.clearAchv++;
            //グーリム
        }
    }

    public void GuardNum()
    {
        AchvManager.instance.guardCount++;
        if(AchvManager.instance.guardClearCount <= AchvManager.instance.guardCount)
        {
            AchvManager.instance.guardCountFlg = true;
            AchvManager.instance.clearAchv++;
            //デックス
        }
    }

    public void NoDamageClear()
    {
        AchvManager.instance.noDamage = true;
        AchvManager.instance.clearAchv++;
        //カース
    }

    public void JustGuardNum()
    {
        AchvManager.instance.justGuardCount++;
        if (AchvManager.instance.justGuardCount >= AchvManager.instance.justGuardClearCount)
        {
            AchvManager.instance.justGuardFlg = true;
            AchvManager.instance.clearAchv++;
            //ワイズ
        }
    }

    public void NoGuardClear()
    {
        AchvManager.instance.noGuard = true;
        AchvManager.instance.clearAchv++;
        //ストレングス
    }

    public void ActiveSkillOnlyClear()
    {
        AchvManager.instance.activeSkillOnlyFlg = true;
        AchvManager.instance.clearAchv++;
        //デスピレイションストライク 
    }
}
