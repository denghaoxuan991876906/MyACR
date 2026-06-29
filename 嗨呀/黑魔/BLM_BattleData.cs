using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔;

public class BLM_BattleData
{
    public static readonly BLM_BattleData Instance = new();

    public List<uint> AfterSpell { get; set; } = [];
    public uint 前一gcd { get; set; }
    public uint 前一能力技 { get; set; }
    public int 已回复蓝量 { get; set; }
    public uint 上次冰火状态 { get; set; }
    public bool 需要即刻 { get; set; }
    public bool 需要瞬发gcd { get; set; }
    public bool 已使用瞬发 { get; set; }
    public bool 火阶段已放耀星 { get; set; }
    public bool 冰阶段已放冰澈 { get; set; }
    public bool 能六火四 { get; set; } = true;
    public int 火阶段已放炽焰数 { get; set; }
    public float 到冰三预估时间 { get; set; }
    public bool 即刻能转好 { get; set; }
    public bool 需要三连 { get; set; }
    public bool 上一gcd瞬发 { get; set; }
    public bool 下个gcd将瞬发 { get; set; }
    public bool 魔泉后待首个Gcd { get; set; }
    public bool 高级循环_冰澈读条完成 { get; set; }
    public bool 高级循环_星灵已完成 { get; set; }
    public uint 高级循环_读条冰澈Gcd { get; set; }
    public bool 三冰针进冰 { get; set; }
    public bool IsInnerOpener { get; set; }

    public void Reset()
    {
        AfterSpell.Clear();
        前一gcd = 0;
        前一能力技 = 0;
        已回复蓝量 = 0;
        上次冰火状态 = 0;
        需要即刻 = false;
        需要瞬发gcd = false;
        已使用瞬发 = false;
        火阶段已放耀星 = false;
        冰阶段已放冰澈 = false;
        能六火四 = true;
        火阶段已放炽焰数 = 0;
        到冰三预估时间 = 0;
        即刻能转好 = false;
        需要三连 = false;
        上一gcd瞬发 = false;
        下个gcd将瞬发 = false;
        魔泉后待首个Gcd = false;
        高级循环_冰澈读条完成 = false;
        高级循环_星灵已完成 = false;
        高级循环_读条冰澈Gcd = 0;
        三冰针进冰 = false;
        IsInnerOpener = false;
    }

    public static bool 在发呆()
    {
        if (Data.Me.Object?.IsDead == true) return false;
        if (!Data.Combat.InCombat) return false;
        if (Data.Me.Object?.IsCasting == true) return false;
        if (GameHelper.GetGCDCooldown() > 0) return false;
        return true;
    }

    public static bool 有转冰瞬发资源()
    {
        if (BLMHelper.Has即刻 || BLMHelper.Has三连) return true;
        if (QTHelper.IsEnabled(QTKey.即刻) && SpellHelper.CanUseSpell(BLMHelper.即刻咏唱)) return true;
        if (QTHelper.IsEnabled(QTKey.三连) && SpellHelper.GetCharges(BLMHelper.三连咏唱) >= 1) return true;
        return false;
    }

    public static bool 应先用魔泉()
    {
        if (GameHelper.GetCurrentLevel() < 58) return false;
        if (!QTHelper.IsEnabled(QTKey.墨泉)) return false;
        if (!BLMHelper.火状态) return false;
        if (SpellHelper.GetCooldownRemaining(BLMHelper.魔泉) < 1000) return false;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (mp > 800) return false;
        if (BLMHelper.耀星层数 == 6 && GameHelper.GetCurrentLevel() == 100) return false;
        if (GameHelper.GetGCDCooldown() < 500) return false;


        return true;
    }

    public static bool 在正常火阶段()
    {
        if (!BLMHelper.火状态) return false;
        if (BLMHelper.火层数 < 3) return false;
        return true;
    }

    public static bool 在火尾整理区()
    {
        if (!BLMHelper.火状态) return false;
        if (BLMHelper.火层数 < 3) return false;
        if (应先用魔泉()) return false;
        if (火尾三连前需先清瞬发()) return true;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (BLMHelper.耀星层数 == 6) return true;
        if (mp <= 3000 && BLMHelper.耀星层数 >= 5) return true;
        if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.火悖论) && mp <= 3000) return true;
        if (mp < 2400 && mp >= 800 && BLMHelper.耀星层数 < 5) return true;

        return false;
    }

    public static bool 雷云需提前处理()
    {
        if (!BLMHelper.Has雷云 || !QTHelper.IsEnabled(QTKey.Dot)) return false;
        if (GameHelper.GetCurrentLevel() >= 92)
        {
            var time = Math.Max(GameHelper.GetStatusTimeLeftOnTarget(3871), GameHelper.GetStatusTimeLeftOnTarget(3872));
            return time < 5f;
        }

        if (GameHelper.GetCurrentLevel() >= 45)
        {
            var time = Math.Max(GameHelper.GetStatusTimeLeftOnTarget(163), GameHelper.GetStatusTimeLeftOnTarget(1210));
            return time < 5f;
        }

        return false;
    }

    public static bool 在转冰整理区()
    {
        var bd = Instance;
        if (bd.魔泉后待首个Gcd) return false;
        if (!BLMHelper.火状态) return false;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        return mp < 800 && !应先用魔泉();
    }

    private static uint 获取转冰补能力窗口SkillIdCore()
    {
        if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.冰悖论))
            return BLMHelper.悖论;

        if (雷云需提前处理())
        {
            if (BLMHelper.群怪模式)
                return GameHelper.GetCurrentLevel() >= 92 ? BLMHelper.高震雷 : GameHelper.GetCurrentLevel() >= 64 ? BLMHelper.霹雷 : BLMHelper.震雷;
            return GameHelper.GetCurrentLevel() >= 92 ? BLMHelper.高闪雷 : GameHelper.GetCurrentLevel() >= 45 ? BLMHelper.暴雷 : BLMHelper.闪雷;
        }

        if (BLMHelper.通晓数 >= 1 && QTHelper.IsEnabled(QTKey.通晓))
            return BLMHelper.群怪模式 ? BLMHelper.秽浊 : BLMHelper.异言;
        if (BLMHelper.悖论指示) return BLMHelper.悖论;
        return 0;
    }

    public static bool 需要转冰补能力窗口()
    {
        if (!BLMHelper.冰状态) return false;
        if (BLMHelper.可瞬发) return false;
        if (BLMHelper.冰层数 >= 3) return false;
        if (GameHelper.RecentlyUsedSpell(BLMHelper.冰封, 1500)) return false;
        return true;
    }

    public static bool 在转冰能力技窗口()
    {
        if (!BLMHelper.冰状态) return false;
        if (可回火()) return false;
        return BLMHelper.冰层数 < 3;
    }

    public static bool 在进冰回复区()
    {
        if (!BLMHelper.冰状态) return false;
        return BLMHelper.冰层数 < 3
            || BLMHelper.冰针数 < 3
            || Instance.三冰针进冰
            || (QTHelper.IsEnabled(QTKey.冰悖论) && BLMHelper.悖论指示);
    }

    public static bool 可回火()
    {
        if (!BLMHelper.冰状态) return false;
        if (BLMHelper.冰层数 < 3) return false;
        if (BLMHelper.冰针数 < 3) return false;
        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (mp < 10000 && Instance.已回复蓝量 < 10000) return false;
        if (Instance.三冰针进冰) return false;
        if (QTHelper.IsEnabled(QTKey.冰悖论) && BLMHelper.悖论指示) return false;
        return true;
    }

    public static bool 火尾三连前需先清瞬发()
    {
        return 火尾三连前清瞬发SkillId() != 0;
    }

    public static uint 火尾三连前清瞬发SkillId()
    {
        if (GameHelper.GetCurrentLevel() != 100) return 0;
        if (!BLMHelper.火状态) return 0;
        if (应先用魔泉()) return 0;

        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (mp > 4400) return 0;
        if (BLMHelper.耀星层数 < 5) return 0;
        if (SpellHelper.GetCharges(BLMHelper.三连咏唱) < 1) return 0;

        var 即刻剩余 = SpellHelper.GetCooldownRemaining(BLMHelper.即刻咏唱);
        var 即刻三Gcd内可用 = 即刻剩余 < GCDHelper.GetGCDDuration() * 3;
        if (SpellHelper.CanUseSpell(BLMHelper.即刻咏唱) || 即刻三Gcd内可用) return 0;

        // 火尾在准备开三连时，先把现成的瞬发GCD清掉，避免三连覆盖浪费。
        if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.火悖论)) return BLMHelper.悖论;
        if (BLMHelper.通晓数 >= 3 && QTHelper.IsEnabled(QTKey.通晓))
            return BLMHelper.群怪模式 ? BLMHelper.秽浊 : BLMHelper.异言;
        if (雷云需提前处理())
        {
            if (BLMHelper.群怪模式)
                return GameHelper.GetCurrentLevel() >= 92 ? BLMHelper.高震雷 : GameHelper.GetCurrentLevel() >= 64 ? BLMHelper.霹雷 : BLMHelper.震雷;
            return GameHelper.GetCurrentLevel() >= 92 ? BLMHelper.高闪雷 : GameHelper.GetCurrentLevel() >= 45 ? BLMHelper.暴雷 : BLMHelper.闪雷;
        }

        return 0;
    }

    public static uint 转冰整理补能力窗口SkillId()
    {
        if (!需要转冰补能力窗口()) return 0;
        return 获取转冰补能力窗口SkillIdCore();
    }
}
