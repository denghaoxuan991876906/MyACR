using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 爆发击 : ISlotResolver
{
    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 30) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.爆发击)) return (int)CheckResult.QT关闭;

        if (ComboHelper.LastComboSpellId == GNBHelper.爆发击 || ComboHelper.LastComboSpellId == GNBHelper.命运之环)
            return (int)CheckResult.最近已用;

        if (!GNBHelper.HasCartridge) return (int)CheckResult.资源不足;

        if (HelperRuntime.GetGCDCooldown() > 500) return (int)CheckResult.冷却中;

        if (QTHelper.IsEnabled(QTKey.AOE))
        {
            var count = HelperRuntime.GetNearbyEnemyCount(5);
            if (count >= 3 && HelperRuntime.GetCurrentLevel() >= 72)
                return (int)GNBHelper.命运之环;
        }

        return (int)GNBHelper.爆发击;
    }

    public void Build(Slot slot)
    {
        var id = Check();
        if (id < 0) return;
        var spellId = (uint)id;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
