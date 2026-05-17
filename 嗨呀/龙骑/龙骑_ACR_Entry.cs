using 嗨呀.龙骑.SlotResolver.Ability;
using 嗨呀.龙骑.SlotResolver.GCD;
using 嗨呀.龙骑.UI;
using 嗨呀.龙骑.设置;

namespace 嗨呀.龙骑;

public class 龙骑_ACR_Entry : IRotationEntry, ISettingsProvider<DRG_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        return new Rotation
        {
            TargetJob = Jobs.DRG,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀龙骑ACR",
            SlotResolvers =
            [
                // GCD
                new SlotResolverData { Resolver = new 基础连击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new AOE连击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 贯穿尖(), Mode = SlotMode.Gcd },

                // Ability
                new SlotResolverData { Resolver = new 猛枪(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 战斗连祷(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 高跳(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 龙剑(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 坠星冲(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 武神枪(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 龙炎升(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 龙炎冲(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 天龙点睛(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 幻象冲(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 死者之岸(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 渡星冲(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 真北(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 低血量恢复(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 牵制(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new 龙骑_EventControl(),
        };
    }

    public IRotationUI? GetRotationUI()
    {
        return new DRGRotationUI();
    }

    public void OnDrawSetting()
    {
    }

    public void Dispose()
    {
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的龙骑ACR");
    }

    public void OnExitRotation()
    {
    }

    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; } = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.DRG];
    public DRG_Setting Settings { get; set; } = new DRG_Setting();
}
