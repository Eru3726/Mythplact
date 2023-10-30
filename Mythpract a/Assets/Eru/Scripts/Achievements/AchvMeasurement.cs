using System.Linq;
using UnityEngine;

public class AchvMeasurement : MonoBehaviour
{
    [ContextMenu("PlayerDie")]
    public void PlayerDie()
    {
        AchvManager.instance.dieXCount++;
        if (AchvManager.instance.dieXCount >= AchvManager.instance.dieClearCount && !AchvManager.instance.dieXFlg)
        {
            AchvManager.instance.dieXFlg = true;
            AchvManager.instance.clearAchv++;
            //サルタリー解放
        }
    }

    [ContextMenu("UseBlink")]
    public void UseBlink()
    {
        AchvManager.instance.blinkXCount++;
        if (AchvManager.instance.blinkXCount >= AchvManager.instance.blinkClearCount && !AchvManager.instance.blinkXFlg)
        {
            AchvManager.instance.blinkXFlg = true;
            AchvManager.instance.clearAchv++;
            //ストライド解放
        }
    }

    public void DefeatedBoss(int i)
    {
        if (!AchvManager.instance.defeatedBoss[i])
        {
            AchvManager.instance.defeatedBoss[i] = true;
            AchvManager.instance.clearBoss++;
        }
        if (AchvManager.instance.defeatedBoss.All(b => b) && !AchvManager.instance.allBossFlg)
        {
            AchvManager.instance.allBossFlg = true;
            AchvManager.instance.clearAchv++;
            //カース解放
        }
    }

    [ContextMenu("OneHpClear")]
    public void OneHpClear()
    {
        if (AchvManager.instance.oneHpFlg) return;
        AchvManager.instance.oneHpFlg = true;
        AchvManager.instance.clearAchv++;
        //アドレナリン解放
    }

    [ContextMenu("AttackCombo")]
    public void AttackCombo()
    {
        if (AchvManager.instance.attackComboFlg) return;
        AchvManager.instance.attackComboFlg = true;
        AchvManager.instance.clearAchv++;
        //ローンウォリアー
    }

    [ContextMenu("UseSheriff")]
    public void UseSheriff()
    {
        AchvManager.instance.sheriffUseCount++;
        if (AchvManager.instance.sheriffUseCount >= AchvManager.instance.sheriffClearCount && !AchvManager.instance.sheriffUseFlg)
        {
            AchvManager.instance.sheriffUseFlg = true;
            AchvManager.instance.clearAchv++;
            //グーリム
        }
    }

    [ContextMenu("GuardNum")]
    public void GuardNum()
    {
        AchvManager.instance.guardCount++;
        if(AchvManager.instance.guardClearCount <= AchvManager.instance.guardCount && !AchvManager.instance.guardCountFlg)
        {
            AchvManager.instance.guardCountFlg = true;
            AchvManager.instance.clearAchv++;
            //デックス
        }
    }

    [ContextMenu("NoDamageClear")]
    public void NoDamageClear()
    {
        if (AchvManager.instance.noDamage) return;
        AchvManager.instance.noDamage = true;
        AchvManager.instance.clearAchv++;
        //カース
    }

    [ContextMenu("JustGuardNum")]
    public void JustGuardNum()
    {
        AchvManager.instance.justGuardCount++;
        if (AchvManager.instance.justGuardCount >= AchvManager.instance.justGuardClearCount && !AchvManager.instance.justGuardFlg)
        {
            AchvManager.instance.justGuardFlg = true;
            AchvManager.instance.clearAchv++;
            //ワイズ
        }
    }

    [ContextMenu("NoGuardClear")]
    public void NoGuardClear()
    {
        if (AchvManager.instance.noGuard) return;
        AchvManager.instance.noGuard = true;
        AchvManager.instance.clearAchv++;
        //ストレングス
    }

    [ContextMenu("ActiveSkillOnlyClear")]
    public void ActiveSkillOnlyClear()
    {
        if (AchvManager.instance.activeSkillOnlyFlg) return;
        AchvManager.instance.activeSkillOnlyFlg = true;
        AchvManager.instance.clearAchv++;
        //デスピレイションストライク 
    }

    [ContextMenu("TimeAttack")]
    public void TimeAttack()
    {
        if (AchvManager.instance.timeAttack) return;
        AchvManager.instance.timeAttack = true;
        AchvManager.instance.clearAchv++;
    }
}
