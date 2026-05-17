using 嗨呀.黑魔.SlotResolver.Ability;
using 嗨呀.黑魔.SlotResolver.GCD;
using 嗨呀.黑魔.SlotResolver.GCD.AOE;
using 嗨呀.黑魔.UI;
using 嗨呀.黑魔.设置;

namespace 嗨呀.黑魔;

public class BLM_ACR_Entry : IRotationEntry, ISettingsProvider<BLM_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        return new Rotation
        {
            TargetJob = Jobs.BLM,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀黑魔ACR",
            SlotResolvers =
            [
                // GCD
                new SlotResolverData { Resolver = new 异言(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 秽浊(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 耀星(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 绝望(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 悖论(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火四(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火三(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 核爆(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火二(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰澈(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰三(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 灵极魂(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 玄冰(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰冻(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 雷(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 雷群(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 瞬发触发器(), Mode = SlotMode.Gcd },

                // Ability
                new SlotResolverData { Resolver = new 即刻三连(), Mode = SlotMode.Always },
                new SlotResolverData { Resolver = new 星灵移位(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 即刻(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 三连咏唱(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 醒梦(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 墨泉(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 详述(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 黑魔纹(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 昏乱(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 爆发药(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new BLM_EventControl(),
        };
    }

    public IRotationUI? GetRotationUI()
    {
        return new BLMRotationUI();
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
    public bool UseCustomUi { get; } = false;
    public IEnumerable<Jobs> TargetJobs => [Jobs.BLM];
    public BLM_Setting Settings { get; set; } = new BLM_Setting();
}
