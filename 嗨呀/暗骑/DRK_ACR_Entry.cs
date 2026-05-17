using 嗨呀.暗骑.SlotResolver.Ability;
using 嗨呀.暗骑.SlotResolver.GCD;
using 嗨呀.暗骑.UI;
using 嗨呀.暗骑.设置;

namespace 嗨呀.暗骑;

public class DRK_ACR_Entry : IRotationEntry, ISettingsProvider<DRK_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        return new Rotation
        {
            TargetJob = Jobs.DRK,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀暗骑ACR",
            SlotResolvers =
            [
                new SlotResolverData { Resolver = new 基础连击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new AOE连击(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 血乱三连(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 暗血技能(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 蔑视(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 伤残(), Mode = SlotMode.Gcd },

                new SlotResolverData { Resolver = new 血乱(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 暗影锋(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 暗影锋AOE(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 掠影(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 腐秽大地(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 精雕怒斩(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 暗影使者(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 腐秽黑暗(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new DRK_EventControl(),
        };
    }

    public IRotationUI? GetRotationUI() => new DRKRotationUI();
    public void OnDrawSetting() {}
    public void Dispose() {}
    public void OnEnterRotation() { Hi.Print("欢迎使用嗨呀的暗骑ACR"); }
    public void OnExitRotation() {}
    public string AuthorName { get; } = "嗨呀";
    public bool UseCustomUi { get; } = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.DRK];
    public DRK_Setting Settings { get; set; } = new();
}
