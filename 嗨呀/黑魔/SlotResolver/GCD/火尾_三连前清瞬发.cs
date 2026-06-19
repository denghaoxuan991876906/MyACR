using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火尾_三连前清瞬发 : ISlotResolver
{
    private uint _skillId;

    public int Check()
    {
        if (GameHelper.GetCurrentLevel() != 100) return (int)CheckResult.等级不足;
        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;
        if (BLMHelper.Has三连 || BLMHelper.Has即刻) return (int)CheckResult.状态不符;
        _skillId = BLM_BattleData.火尾三连前清瞬发SkillId();
        if (_skillId != 0)
            return 0;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
