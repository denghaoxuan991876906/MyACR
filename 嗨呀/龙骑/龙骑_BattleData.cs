namespace 嗨呀.龙骑;

public class 龙骑_BattleData
{
    public static readonly 龙骑_BattleData Instance = new();

    public List<uint> AfterSpell { get; set; } = [];
    public uint 前一gcd { get; set; }
    public uint 前一能力技 { get; set; }

    public void Reset()
    {
        AfterSpell.Clear();
        前一gcd = 0;
        前一能力技 = 0;
    }

    public static bool 在发呆()
    {
        if (!Data.Combat.InCombat) return false;
        if (GameHelper.GetGCDCooldown() > 0) return false;
        return true;
    }
}
