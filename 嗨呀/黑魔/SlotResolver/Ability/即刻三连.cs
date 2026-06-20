using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

// 发呆时(战斗中GCD好转却没放技能)自动激发即刻/三连，避免读条卡死
public class 即刻三连 : ISlotResolver
{
    private uint _skillId;

    public int Check()
    {
        if (!BLM_BattleData.Instance.需要即刻) return (int)CheckResult.状态不符;
        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;
        _skillId = SkillId();
        if (_skillId == 0) return (int)CheckResult.技能未就绪;
        if (_skillId == BLMHelper.三连咏唱 && !QTHelper.IsEnabled(QTKey.三连))
            return (int)CheckResult.QT关闭;
        return 0;
    }

    public void Build(Slot slot)
    {
        BLM_BattleData.Instance.需要即刻 = false;
        BLM_BattleData.Instance.下个gcd将瞬发 = true;
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }

    private static uint SkillId()
    {
        if (BLMHelper.可瞬发) return 0;
        if (QTHelper.IsEnabled(QTKey.三连) && SpellHelper.GetCharges(BLMHelper.三连咏唱) >= 1) return BLMHelper.三连咏唱;
        if (SpellHelper.CanUseSpell(BLMHelper.即刻咏唱)) return BLMHelper.即刻咏唱;
        return 0;
    }
}
