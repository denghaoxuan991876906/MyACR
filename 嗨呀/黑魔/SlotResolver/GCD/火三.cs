using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火三 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 60) return (int)CheckResult.等级不足;

        if (BLMHelper.冰状态 && (BLMHelper.火状态 || (Data.Me.Object?.CurrentMp < 800 || BLMHelper.耀星层数 == 6)) && BLMHelper.群怪模式)
            return (int)HelperRuntime.GetActionChange(BLMHelper.爆炎);

        if (!BLMHelper.火状态 && !BLMHelper.冰状态 && Data.Me.Object?.CurrentMp >= 9800)
            return (int)HelperRuntime.GetActionChange(BLMHelper.爆炎);

        if (BLMHelper.火状态 && BLMHelper.火层数 < 3 && BLMHelper.Has火苗)
            return (int)HelperRuntime.GetActionChange(BLMHelper.爆炎);

        if (BLMHelper.冰状态 && Data.Me.Object?.CurrentMp < 800)
            return (int)HelperRuntime.GetActionChange(BLMHelper.爆炎);

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        var spellId = HelperRuntime.GetActionChange(BLMHelper.爆炎);
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
