using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 高级循环_绝望 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 100) return (int)CheckResult.等级不足;
        if (!QTHelper.IsEnabled(QTKey.高级循环)) return (int)CheckResult.QT关闭;
        if (!BLMHelper.火状态) return (int)CheckResult.高级循环绝望_未进火;
        if (BLMHelper.火层数 >= 3) return (int)CheckResult.高级循环绝望_星灵未完成;
        if (!BLM_BattleData.Instance.高级循环_冰澈读条完成) return (int)CheckResult.高级循环绝望_前一Gcd不符;
        if (!GameHelper.RecentlyUsedSpell(BLMHelper.冰澈, (int)GCDHelper.GetGCDDuration())) return (int)CheckResult.高级循环绝望_前一Gcd不符;
        var mp = Data.Me.Object?.CurrentMp ?? 0;
        if (mp < 800) return (int)CheckResult.资源不足;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.绝望, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
