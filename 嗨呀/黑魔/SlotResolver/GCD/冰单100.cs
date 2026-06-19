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

        // 无状态：高蓝去进火，低蓝先进冰恢复
        if (!BLMHelper.火状态 && !BLMHelper.冰状态)
        {
            if (mp >= 6600) return 0;

            return BLMHelper.冰封;
        }
        if (BLMHelper.火状态)
        {
            var 可等三连 = QTHelper.IsEnabled(QTKey.三连) && SpellHelper.GetCharges(BLMHelper.三连咏唱) >= 1;
            var 可等即刻 = QTHelper.IsEnabled(QTKey.即刻) && SpellHelper.GetCooldownRemaining(BLMHelper.即可咏唱) <= 1000.0f;
            if (mp < 800 && !BLM_BattleData.应先用魔泉() && !BLMHelper.可瞬发 && !可等三连 && !可等即刻)
                return BLMHelper.冰封;
            return 0;
        }


        if (BLM_BattleData.需要转冰补能力窗口())
        {
            if (BLM_BattleData.转冰整理补能力窗口SkillId() != 0)
                return 0;
        }

        // 正常冰段回复：先稳定冰3，再补冰针，最后处理冰悖论
        if (BLM_BattleData.在进冰回复区())
        {
            if (BLMHelper.冰层数 < 3)
                return BLMHelper.冰封;

            if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.冰悖论) && QTHelper.IsEnabled(QTKey.高级循环))
                return BLMHelper.悖论;

            if (BLMHelper.冰针数 < 3 || bd.三冰针进冰)
                return BLMHelper.冰澈;

            if (BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.冰悖论))
                return BLMHelper.悖论;

            return 0;
        }

        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}


