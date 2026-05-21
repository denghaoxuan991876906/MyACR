using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 星灵移位 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 4) return (int)CheckResult.等级不足;

        if (CooldownHelper.GetCooldownRemaining(BLMHelper.星灵移位) > 0) return (int)CheckResult.冷却中;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态) return (int)CheckResult.状态不符;

        if (HelperRuntime.GetCurrentLevel() < 80) return (int)CheckResult.状态不符;

        if (BLMHelper.火状态)
        {
            if (HelperRuntime.GetCurrentLevel() >= 100 && !BLM_BattleData.Instance.火阶段已放耀星)
                return (int)CheckResult.状态不符;

            if (CooldownHelper.GetCooldownRemaining(BLMHelper.魔泉) <= 0 && QTHelper.IsEnabled("墨泉"))
                return (int)CheckResult.状态不符;

            if (Data.Me.Object?.CurrentMp >= 800) return (int)CheckResult.资源不足;

            if (HelperRuntime.GetCurrentLevel() >= 100)
            {
                var hasInstantAbility = CooldownHelper.GetCooldownRemaining(BLMHelper.即可咏唱) <= 0
                    || CooldownHelper.GetCharges(BLMHelper.三连咏唱) >= 1;
                if (!hasInstantAbility && !Data.Me.IsMoving)
                    return (int)CheckResult.状态不符;
            }

            return 1;
        }

        if (BLMHelper.冰状态)
        {
            if (BLMHelper.冰层数 != 3) return (int)CheckResult.状态不符;

            if (!QTHelper.IsEnabled(QTKey.高级循环))
            {
                if (BLMHelper.冰针数 < 3) return (int)CheckResult.资源不足;

                if (BLM_BattleData.Instance.已回复蓝量 < 10000) return (int)CheckResult.资源不足;
            }

            if (BLMHelper.悖论指示) return (int)CheckResult.状态不符;

            return 1;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.星灵移位, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
