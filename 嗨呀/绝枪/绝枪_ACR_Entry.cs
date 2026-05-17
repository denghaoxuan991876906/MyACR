using 嗨呀.绝枪.SlotResolver.Ability;
using 嗨呀.绝枪.SlotResolver.GCD;
using 嗨呀.绝枪.UI;
using 嗨呀.绝枪.设置;

namespace 嗨呀.绝枪;

public class 绝枪_ACR_Entry : IRotationEntry, ISettingsProvider<GNB_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        return new Rotation
        {
            TargetJob = Jobs.GNB,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀绝枪ACR",
            SlotResolvers =
            [
                // GCD
                new SlotResolverData { Resolver = new 血壤连(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 倍功(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 子弹连(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 子弹连溢出(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 爆发击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 音速破(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 基础连击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 闪雷弹(), Mode = SlotMode.Gcd },

                // Ability
                new SlotResolverData { Resolver = new 无情(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 续剑(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 血壤(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 弓形冲波(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 爆破领域(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new 绝枪_EventControl(),
        };
    }

    public IRotationUI? GetRotationUI()
    {
        return new GNBRotationUI();
    }

    public void OnDrawSetting()
    {
    }

    public void Dispose()
    {
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的绝枪ACR");
    }

    public void OnExitRotation()
    {
    }

    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; } = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.GNB];
    public GNB_Setting Settings { get; set; } = new GNB_Setting();
}
