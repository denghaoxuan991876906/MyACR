using HiAuRo.Runtime;
using 嗨呀.黑魔.UI;
using 嗨呀.黑魔.设置;

namespace 嗨呀.黑魔.起手;

public class BLM_Open100 :IOpener
{
    
    public void InitCountDown(CountDownHandler handler)
    {
        if (BLM_Setting.Instance.提前黑魔纹)
        {
            var spellTime = 2500 + 300;
            handler.AddAction(spellTime + 600, BLMHelper.黑魔纹, SpellTargetType.Self);
            handler.AddAction(spellTime, BLMHelper.爆炎, SpellTargetType.Target);
        }
        else
        {
            var spellTime = 2500 + 300;
            handler.AddAction(spellTime, BLMHelper.爆炎, SpellTargetType.Target);
        }
    }

    public int StartCheck()
    {
        return 1;
    }

    public int StopCheck(int index)
    {
        return -1;
    }

    public List<Action<Slot>> Sequence { get; } =
    [
        Step1, Step3, Step4, Step5, Step6, Step7
    ];

    public uint Level => 100;

    private static void Step1(Slot slot)
    {
        slot.Add(new Spell { Id = HelperRuntime.GetActionChange(BLMHelper.闪雷), TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });

        slot.Add(new Spell { Id = BLMHelper.即可咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
        slot.Add(new Spell { Id = BLMHelper.详述, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        if (QTHelper.IsEnabled("爆发药"))
            slot.Add(Spell.CreatePotion());
        if (!BLM_Setting.Instance.提前黑魔纹)
            slot.Add(new Spell { Id = BLMHelper.黑魔纹, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }

    private static void Step2(Slot slot)
    {
    }

    private static void Step3(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.异言, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }

    private static void Step4(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.绝望, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.魔泉, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }

    private static void Step5(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.耀星, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = HelperRuntime.GetActionChange(BLMHelper.闪雷), TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.炽焰, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }

    private static void Step6(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.悖论, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        if (!QTHelper.IsEnabled(QTKey.起手不三连))
            slot.Add(new Spell { Id = BLMHelper.三连咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }

    private static void Step7(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.核爆, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        slot.Add(new Spell { Id = BLMHelper.耀星, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        if (!QTHelper.IsEnabled(QTKey.起手不三连))
            slot.Add(new Spell { Id = BLMHelper.星灵移位, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
        else
        {
            slot.Add(new Spell { Id = BLMHelper.冰封, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
        }

    }
}
