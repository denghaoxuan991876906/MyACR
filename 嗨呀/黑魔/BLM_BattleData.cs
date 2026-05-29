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
    public bool 能六火四 { get; set; } = true;
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
        能六火四 = true;
        IsInnerOpener = false;
    }

    public static bool 在发呆()
    {
        if (!Data.Combat.InCombat) return false;
        if (HelperRuntime.GetGCDCooldown() > 0) return false;
        return true;
    }
}