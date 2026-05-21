using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火三 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发 && !BLMHelper.Has火苗) return (int)CheckResult.移动中;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态 && Data.Me.Object?.CurrentMp >= 9800)
            return (int)BLMHelper.爆炎;

        if (BLMHelper.火状态 && BLMHelper.火层数 < 3 && BLMHelper.Has火苗)
            return (int)BLMHelper.爆炎;

        if (BLMHelper.冰状态 && BLM_BattleData.Instance.已回复蓝量 >= 10000 && BLMHelper.冰针数 >= 3)
            return (int)BLMHelper.爆炎;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        var spellId = BLMHelper.爆炎;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
