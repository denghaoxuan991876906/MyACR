using HiAuRo.ACR;
using HiAuRo.Runtime;
using 嗨呀.黑魔.设置;

namespace 嗨呀.黑魔;

public class BLM_ACR_Entry : IRotationEntry
{
    public Rotation? Build(string settingFolder)
    {
        BLM_Setting.Init(settingFolder);
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
        return null;
    }

    public void OnDrawSetting()
    {
        
    }

    public void Dispose()
    {
        
    }

    public void OnEnterRotation()
    {
        
    }

    public void OnExitRotation()
    {
        
    }

    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; }  = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.BLM];
}