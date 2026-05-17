namespace 嗨呀.绝枪;

public class 绝枪_BattleData
{
    public static readonly 绝枪_BattleData Instance = new();

    public int 基础连击步数 { get; set; }
    public int 子弹连步骤 { get; set; }
    public int 血壤连步骤 { get; set; }
    public bool 无情中 { get; set; }
    public uint 子弹数 { get; set; }
    public bool 续剑 { get; set; }
    public List<uint> AfterSpell { get; set; } = [];

    public void Reset()
    {
        基础连击步数 = 0;
        子弹连步骤 = 0;
        血壤连步骤 = 0;
        无情中 = false;
        子弹数 = 0;
        续剑 = false;
        AfterSpell.Clear();
    }
}
