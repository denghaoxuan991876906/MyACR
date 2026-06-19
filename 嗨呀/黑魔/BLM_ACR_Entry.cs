using 嗨呀.黑魔.SlotResolver.Ability;
using 嗨呀.黑魔.SlotResolver.GCD;
using 嗨呀.黑魔.UI;
using 嗨呀.黑魔.设置;
using 嗨呀.黑魔.起手;

namespace 嗨呀.黑魔;

public class BLM_ACR_Entry : IRotationEntry, ISettingsProvider<BLM_Setting>
{
    public Rotation? Build(string settingFolder)
    {
        BLM_Setting.Instance = Settings;
        return new Rotation
        {
            TargetJob = Jobs.BLM,
            AcrType = AcrType.PvE,
            MinLevel = 1,
            MaxLevel = 100,
            Description = "嗨呀黑魔ACR",
            SlotResolvers =
            [
                // Always（立即响应：发呆激发）
                //new SlotResolverData { Resolver = new 即刻三连(), Mode = SlotMode.Always },

                // GCD
                new SlotResolverData { Resolver = new 高级循环_绝望(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 瞬发触发器(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火尾_三连前清瞬发(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 高闪雷(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 异言(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 秽浊(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火单100(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰单100(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 转冰整理_补能力窗口(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火单90(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰单90(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火单80(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰单80(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 火单70(), Mode = SlotMode.Gcd },
                new SlotResolverData { Resolver = new 冰单70(), Mode = SlotMode.Gcd },

                // OffGcd
                new SlotResolverData { Resolver = new 高级循环_星灵移位(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 星灵移位(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 黑魔纹(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 详述(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 魔泉(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 即刻(), Mode = SlotMode.OffGcd },
                new SlotResolverData { Resolver = new 三连(), Mode = SlotMode.OffGcd },
            ],
            EventHandler = new BLM_EventControl(),
            Opener = new BLM_Open100(),
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
    public AcrType AcrType => AcrType.PvE;
    public BLM_Setting Settings { get; set; } = new BLM_Setting();
}
