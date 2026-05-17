using 嗨呀.舞者.SlotResolver.Ability;
using 嗨呀.舞者.SlotResolver.GCD;
using 嗨呀.舞者.UI;
using 嗨呀.舞者.设置;

namespace 嗨呀.舞者;

public class 舞者_ACR_Entry : IRotationEntry, ISettingsProvider<DNC_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        return new Rotation
        {
            TargetJob = Jobs.DNC,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀舞者ACR",
            SlotResolvers =
            [
                new SlotResolverData { Resolver = new 流星舞(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 落幕舞(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 提拉纳(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 剑舞(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 对称投掷(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 非对称投掷(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 大舞(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 小舞(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 基础连击(), Mode = SlotMode.Gcd },

                new SlotResolverData { Resolver = new 百花(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 扇舞急(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 扇舞终(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 扇舞序(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 探戈(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 桑巴(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 恢复(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new 舞者_EventControl(),
        };
    }

    public IRotationUI? GetRotationUI()
    {
        return new DNCRotationUI();
    }

    public void OnDrawSetting()
    {
    }

    public void Dispose()
    {
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的舞者ACR");
    }

    public void OnExitRotation()
    {
    }

    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; } = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.DNC];
    public DNC_Setting Settings { get; set; } = new DNC_Setting();
}
