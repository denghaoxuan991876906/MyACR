using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.Ability;

public class 三连 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 66) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.三连)) return (int)CheckResult.QT关闭;
        if (GameHelper.RecentlyUsedSpell(BLMHelper.三连咏唱, 2000)) return (int)CheckResult.最近已用;
        if (BLMHelper.Has三连) return (int)CheckResult.状态不符;
        var charges = SpellHelper.GetCharges(BLMHelper.三连咏唱);
        if (charges < 1) return (int)CheckResult.冷却中;
        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;

        var bd = BLM_BattleData.Instance;
        if (BLMHelper.火状态)
        {
            if (BLMHelper.火层数 < 3) return (int)CheckResult.状态不符;
            if (GameHelper.RecentlyUsedSpell(BLMHelper.星灵移位, 2000)) return (int)CheckResult.状态不符;
            if (QTHelper.IsEnabled(QTKey.墨泉) && SpellHelper.CanUseSpell(BLMHelper.魔泉) && BLMHelper.火状态) return (int)CheckResult.状态不符;
            if (BLM_BattleData.火尾三连前需先清瞬发()) return (int)CheckResult.状态不符;

            var 即刻剩余 = SpellHelper.GetCooldownRemaining(BLMHelper.即刻咏唱);
            var 即刻三Gcd内可用 = 即刻剩余 < GCDHelper.GetGCDDuration() * 3;
            var mp = Data.Me.Object?.CurrentMp ?? 0;

            if (mp <= 4400 && BLMHelper.耀星层数 >= 5 && GameHelper.GetCurrentLevel() == 100
                && !SpellHelper.CanUseSpell(BLMHelper.即刻咏唱) && !即刻三Gcd内可用)
                return 0;

            return (int)CheckResult.状态不符;
        }

        if (BLMHelper.冰状态 && GameHelper.GetCurrentLevel() >= 100)
        {
            if (BLMHelper.群怪模式) return (int)CheckResult.群怪模式;
            if (GameHelper.RecentlyUsedSpell(BLMHelper.冰封, 1500)) return (int)CheckResult.状态不符;
            if (BLMHelper.冰层数 >= 3) return (int)CheckResult.状态不符;
            if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;
            if (QTHelper.IsEnabled(QTKey.即刻) && SpellHelper.CanUseSpell(BLMHelper.即刻咏唱)) return (int)CheckResult.状态不符;
            return 0;
        }

        return (int)CheckResult.状态不符;
    }

    public void Build(Slot slot)
    {
        BLM_BattleData.Instance.下个gcd将瞬发 = true;
        slot.Add(new Spell { Id = BLMHelper.三连咏唱, TargetType = SpellTargetType.Self, Type = SpellType.Ability });
    }
}
