using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火单90 : ISlotResolver
{
    private uint _skillId;

    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 90 || GameHelper.GetCurrentLevel() >= 100) return (int)CheckResult.等级不足;
        if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;
        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        _skillId = GetSkillId();
        if (_skillId == 0) return (int)CheckResult.状态不符;
        return 0;
    }

    private uint GetSkillId()
    {
        var mp = Data.Me.Object?.CurrentMp ?? 0;

        if (BLMHelper.火状态)
        {
            if (BLMHelper.火层数 < 3)
            {
                if (BLMHelper.Has火苗) return BLMHelper.爆炎;
                if (BLMHelper.悖论指示) return BLMHelper.悖论;
                return BLMHelper.爆炎;
            }

            if (mp >= 800 && mp < 2400) return BLMHelper.绝望;
            if (mp >= 2400 && mp < 4000 && BLMHelper.悖论指示) return BLMHelper.悖论;
            return BLMHelper.炽焰;
        }

        if (BLMHelper.冰状态)
        {
            if (BLMHelper.冰层数 == 3 && BLMHelper.冰针数 == 3) return BLMHelper.爆炎;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
