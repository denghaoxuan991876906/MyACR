using 嗨呀.黑魔.UI;
using 嗨呀.黑魔.设置;

namespace 嗨呀.黑魔;

public class BLM_ACR_Entry : IRotationEntry,ISettingsProvider<BLM_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        
        return new Rotation
        {
            TargetJob = Jobs.BLM,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "黑魔ACR"
        };
    }

    public IRotationUI? GetRotationUI()
    {
        
        return new BLMRotationUI() ;
    }

    public void OnDrawSetting()
    {
        
    }

    public void Dispose()
    {
        
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的黑魔ACR");
    }

    public void OnExitRotation()
    {
        
    }

    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; }  = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.BLM];
    public BLM_Setting Settings { get; set; } = new BLM_Setting();
}