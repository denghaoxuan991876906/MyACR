using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 冰单100 : ISlotResolver
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
        var bd = BLM_BattleData.Instance;
        var mp = Data.Me.Object?.CurrentMp ?? 0;
        var 即刻可在下个Gcd内使用 = SpellHelper.CanUseSpell(BLMHelper.即可咏唱)
            || SpellHelper.GetCooldownRemaining(BLMHelper.即可咏唱) < GCDHelper.GetGCDDuration();

        if (BLMHelper.火状态 && mp < 800 && BLMHelper.耀星层数 != 6)
        {
            if (bd.前一gcd is BLMHelper.冰澈 or BLMHelper.玄冰 && bd.前一能力技 == BLMHelper.星灵移位)
                return 0;
            if (BLM_BattleData.应先用魔泉())
                return 0;
            return BLMHelper.冰封;
        }

        if (BLMHelper.冰状态)
        {
            if (BLMHelper.冰层数 < 3)
            {
                if (BLMHelper.悖论指示 && BLM_BattleData.有转冰瞬发资源() && !BLMHelper.可瞬发)
                    return BLMHelper.悖论;
                if (BLMHelper.可瞬发)
                    return BLMHelper.冰封;
            }

            if (BLMHelper.冰针数 < 3 || bd.三冰针进冰)
                return BLMHelper.冰澈;

            if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.冰悖论) && !QTHelper.IsEnabled(QTKey.高级循环))
                return BLMHelper.悖论;

            return 0;
        }

        if (!BLMHelper.冰状态 && !BLMHelper.火状态)
        {
            if (即刻可在下个Gcd内使用 && BLMHelper.悖论指示 && !BLMHelper.可瞬发)
                return BLMHelper.悖论;
            return BLMHelper.冰封;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
