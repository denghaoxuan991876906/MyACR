using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火单100 : ISlotResolver
{
    private uint _skillId;

    public int Check()
    {
        if (GameHelper.GetCurrentLevel() != 100) return (int)CheckResult.等级不足;
        if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;
        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        _skillId = GetSkillId();
        if (_skillId == 0) return (int)CheckResult.状态不符;
        return 0;
    }

    private uint GetSkillId()
    {
        var mp = Data.Me.Object?.CurrentMp ?? 0;
        var 火四成本 = BLMHelper.冰针数 > 0 ? 800u : 1600u;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态 && mp >= 9800)
            return BLMHelper.爆炎;

        if (BLMHelper.冰状态 || !BLMHelper.火状态)
            return 0;

        if (BLMHelper.火层数 < 3)
        {
            if (BLMHelper.Has火苗)
                return BLMHelper.爆炎;
            if (BLMHelper.悖论指示)
                return BLMHelper.悖论;
        }

        if (BLMHelper.耀星层数 == 6)
            return BLMHelper.耀星;

        if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.火悖论))
        {
            if (mp >= 2400 && mp <= 3000)
                return BLMHelper.悖论;
        }

        if (!QTHelper.IsEnabled(QTKey.火悖论) && mp <= 2800 && BLMHelper.耀星层数 < 5)
            return BLMHelper.绝望;

        if (mp < 2400 && BLMHelper.耀星层数 < 5 && mp >= 800)
            return BLMHelper.绝望;

        if (mp >= 火四成本)
            return BLMHelper.炽焰;

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
