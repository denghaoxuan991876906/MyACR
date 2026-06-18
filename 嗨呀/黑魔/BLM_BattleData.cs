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
        if (!Data.Combat.InCombat) return false;
        if (GameHelper.GetGCDCooldown() > 0) return false;
        return true;
    }

    public static bool 有转冰瞬发资源()
    {
        if (BLMHelper.Has即刻 || BLMHelper.Has三连) return true;
        if (QTHelper.IsEnabled(QTKey.即刻) && SpellHelper.CanUseSpell(BLMHelper.即可咏唱)) return true;
        if (QTHelper.IsEnabled(QTKey.三连) && SpellHelper.GetCharges(BLMHelper.三连咏唱) >= 1) return true;
        return false;
    }

    public static bool 应先用魔泉()
    {
        return QTHelper.IsEnabled(QTKey.墨泉) && SpellHelper.CanUseSpell(BLMHelper.魔泉);
    }
}
