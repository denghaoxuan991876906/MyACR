namespace 嗨呀.暗骑;

public class DRK_BattleData
{
    public static readonly DRK_BattleData Instance = new();

    public List<uint> AfterSpell { get; set; } = [];
    public uint 前一gcd { get; set; }
    public uint 前一能力技 { get; set; }
    public bool 使用血乱次数 { get; set; }
    public int 爆发开始时间 { get; set; }

    public void Reset()
    {
        AfterSpell.Clear();
        前一gcd = 0;
        前一能力技 = 0;
        使用血乱次数 = false;
        爆发开始时间 = 0;
    }
}
