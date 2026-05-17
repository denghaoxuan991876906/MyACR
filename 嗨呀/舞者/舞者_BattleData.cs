namespace 嗨呀.舞者;

public class 舞者_BattleData
{
    public static readonly 舞者_BattleData Instance = new();

    public uint 前一能力技 { get; set; }
    public bool 需应急治疗 { get; set; }

    public void Reset()
    {
        前一能力技 = 0;
        需应急治疗 = false;
    }
}
