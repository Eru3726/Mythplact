using System.Linq;
using UnityEngine;

public class AchvMeasurement : MonoBehaviour
{
    [Header("実績解除死亡回数")]
    public int dieClearCount = 3;

    [Header("実績解除ブリンク回数")]
    public int blinkClearCount = 3;

    [Header("実績解除シェリフ回数")]
    public int sheriffClearCount = 3;

    [Header("実績解除ガード回数")]
    public int guardClearCount = 3;

    [Header("実績解除ジャストガード回数")]
    public int justGuardClearCount = 3;

    [Header("実績解除タイム")]
    public float timeAttackCount = 60;

    public static AchvMeasurement instance = new();

    /// <summary>
    /// 累計プレイヤー死亡
    /// </summary>
    [ContextMenu("PlayerDie")]
    public void PlayerDie()
    {
        GameData.dieXCount++;
        if (GameData.dieXCount >= dieClearCount && !GameData.dieXFlg)
        {
            GameData.dieXFlg = true;
            GameData.clearAchv++;
            //サルタリー解放
        }
    }

    /// <summary>
    /// 累計ブリンク回数
    /// </summary>
    [ContextMenu("UseBlink")]
    public void UseBlink()
    {
        GameData.blinkXCount++;
        if (GameData.blinkXCount >= blinkClearCount && !GameData.blinkXFlg)
        {
            GameData.blinkXFlg = true;
            GameData.clearAchv++;
            //ストライド解放
        }
    }

    /// <summary>
    /// ボス討伐
    /// </summary>
    /// <param name="i">0=ショゴス　1=フィファニール　2=キリン</param>
    public void DefeatedBoss(int i)
    {
        if (!GameData.defeatedBoss[i])
        {
            GameData.defeatedBoss[i] = true;
            GameData.clearBoss++;
        }
        if (GameData.defeatedBoss.All(b => b) && !GameData.allBossFlg)
        {
            GameData.allBossFlg = true;
            GameData.clearAchv++;
            //カース解放
        }
    }

    /// <summary>
    /// 体力1でクリア
    /// </summary>
    [ContextMenu("OneHpClear")]
    public void OneHpClear()
    {
        if (GameData.oneHpFlg) return;
        GameData.oneHpFlg = true;
        GameData.clearAchv++;
        //アドレナリン解放
    }

    /// <summary>
    /// コンボ回数
    /// </summary>
    [ContextMenu("AttackCombo")]
    public void AttackCombo()
    {
        if (GameData.attackComboFlg) return;
        GameData.attackComboFlg = true;
        GameData.clearAchv++;
        //ローンウォリアー
    }

    /// <summary>
    /// 累計シェリフ使用回数
    /// </summary>
    [ContextMenu("UseSheriff")]
    public void UseSheriff()
    {
        GameData.sheriffUseCount++;
        if (GameData.sheriffUseCount >= sheriffClearCount && !GameData.sheriffUseFlg)
        {
            GameData.sheriffUseFlg = true;
            GameData.clearAchv++;
            //グーリム
        }
    }

    /// <summary>
    /// 累計ガード回数
    /// </summary>
    [ContextMenu("GuardNum")]
    public void GuardNum()
    {
        GameData.guardCount++;
        if(guardClearCount <= GameData.guardCount && !GameData.guardCountFlg)
        {
            GameData.guardCountFlg = true;
            GameData.clearAchv++;
            //デックス
        }
    }

    /// <summary>
    /// ノーダメクリア
    /// </summary>
    [ContextMenu("NoDamageClear")]
    public void NoDamageClear()
    {
        if (GameData.noDamage) return;
        GameData.noDamage = true;
        GameData.clearAchv++;
        //カース
    }

    /// <summary>
    /// 累計ジャストガード回数
    /// </summary>
    [ContextMenu("JustGuardNum")]
    public void JustGuardNum()
    {
        GameData.justGuardCount++;
        if (GameData.justGuardCount >= justGuardClearCount && !GameData.justGuardFlg)
        {
            GameData.justGuardFlg = true;
            GameData.clearAchv++;
            //ワイズ
        }
    }

    /// <summary>
    /// ノーガードクリア
    /// </summary>
    [ContextMenu("NoGuardClear")]
    public void NoGuardClear()
    {
        if (GameData.noGuard) return;
        GameData.noGuard = true;
        GameData.clearAchv++;
        //ストレングス
    }

    /// <summary>
    /// パッシブスキルを使用せずクリア
    /// </summary>
    [ContextMenu("ActiveSkillOnlyClear")]
    public void ActiveSkillOnlyClear()
    {
        if (GameData.activeSkillOnlyFlg) return;
        GameData.activeSkillOnlyFlg = true;
        GameData.clearAchv++;
        //デスピレイションストライク 
    }

    /// <summary>
    /// タイムアタック
    /// </summary>
    [ContextMenu("TimeAttack")]
    public void TimeAttack()
    {
        if (GameData.timeAttack) return;
        GameData.timeAttack = true;
        GameData.clearAchv++;
    }
}
