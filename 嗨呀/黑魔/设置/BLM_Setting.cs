
namespace 嗨呀.黑魔.设置;

public class BLM_Setting : AcrSettings
{
    public bool test1  = false;
    public static BLM_Setting Instance { get; set; } = new BLM_Setting();
    public int test2  = 0;
    public bool 起手 { get; set; }
    public bool 提前黑魔纹 { get; set; }

}