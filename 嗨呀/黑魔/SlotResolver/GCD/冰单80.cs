using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 冰单80 : ISlotResolver
{
    private uint _skillId;

    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 80 || GameHelper.GetCurrentLevel() >= 90) return (int)CheckResult.等级不足;
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

        if (BLMHelper.冰状态)
        {
            if (BLMHelper.冰层数 < 3) return BLMHelper.冰封;
            if (BLMHelper.冰针数 < 3 || bd.三冰针进冰) return BLMHelper.冰澈;
            return 0;
        }

        if (BLMHelper.火状态)
        {
            if (bd.前一gcd is BLMHelper.冰澈 or BLMHelper.玄冰 && bd.前一能力技 == BLMHelper.星灵移位) return 0;
            if (mp < 800) return BLMHelper.冰封;
        }

        if (!BLMHelper.冰状态 && !BLMHelper.火状态) return BLMHelper.冰封;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}


