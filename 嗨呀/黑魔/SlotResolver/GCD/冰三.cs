using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 冰三 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 35) return (int)CheckResult.等级不足;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (BLMHelper.火状态 && !BLMHelper.群怪模式 && BLMHelper.耀星层数 < 6)
        {
            if (GameHelper.GetCurrentLevel() < 80)
            {
                var fire4Cost = BLMHelper.冰针数 > 0 ? 800 : 1600;
                if (Data.Me.Object?.CurrentMp < fire4Cost)
                    return (int)BLMHelper.冰封;
            }
            else if (Data.Me.Object?.CurrentMp < 800)
            {
                return (int)BLMHelper.冰封;
            }
        }

        if (BLMHelper.冰状态 && BLMHelper.冰层数 < 3)
            return (int)BLMHelper.冰封;

        if (!BLMHelper.火状态 && !BLMHelper.冰状态)
            return (int)BLMHelper.冰封;

        if (QTHelper.IsEnabled(QTKey.AOE) && BLMHelper.群怪模式) return (int)CheckResult.群怪模式;

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        var spellId = BLMHelper.冰封;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
