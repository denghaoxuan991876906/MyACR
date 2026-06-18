using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.龙骑.SlotResolver.Ability;

public class 低血量恢复 : ISlotResolver
{
    private bool _useBloodbath;

    public int Check()
    {
        var hp = Data.Me.Object?.CurrentHp ?? 0;
        var maxHp = Data.Me.Object?.MaxHp ?? 1;
        var hpPct = (float)hp / maxHp;

        if (hpPct > 0.3f) return (int)CheckResult.状态不符;

        var level = GameHelper.GetCurrentLevel();

        if (level >= 12 && CooldownHelper.GetCooldownRemaining(DRGHelper.内丹) <= 0)
        {
            _useBloodbath = false;
            return 1;
        }

        if (level >= 56 && CooldownHelper.GetCooldownRemaining(DRGHelper.浴血) <= 0)
        {
            _useBloodbath = true;
            return 1;
        }

        return (int)CheckResult.技能未就绪;
    }

    public void Build(Slot slot)
    {
        if (_useBloodbath)
            slot.Add(new Spell { Id = DRGHelper.浴血, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
        else
            slot.Add(new Spell { Id = DRGHelper.内丹, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
