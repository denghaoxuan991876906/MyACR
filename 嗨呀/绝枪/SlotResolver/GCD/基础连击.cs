using 嗨呀.绝枪.UI;
using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.绝枪.SlotResolver.GCD;

public class 基础连击 : ISlotResolver
{
    public int Check()
    {
        if (QTHelper.IsEnabled(QTKey.AOE))
        {
            var count = HelperRuntime.GetNearbyEnemyCount(5);
            if (count >= 3)
            {
                if (ComboHelper.LastComboSpellId == GNBHelper.恶魔切)
                    return (int)GNBHelper.恶魔杀;
                if (HelperRuntime.GetCurrentLevel() >= 40)
                    return (int)GNBHelper.恶魔切;
                return (int)CheckResult.等级不足;
            }
        }

        if (ComboHelper.LastComboSpellId == GNBHelper.残暴弹技能 || ComboHelper.LastComboSpellId == GNBHelper.残暴弹)
        {
            if (HelperRuntime.GetCurrentLevel() >= 60)
                return (int)GNBHelper.讯连斩;
            return (int)CheckResult.等级不足;
        }

        if (ComboHelper.LastComboSpellId == GNBHelper.利刃斩)
        {
            if (HelperRuntime.GetCurrentLevel() >= 26)
                return (int)GNBHelper.残暴弹技能;
            return (int)CheckResult.等级不足;
        }

        return (int)GNBHelper.利刃斩;
    }

    public void Build(Slot slot)
    {
        var id = Check();
        if (id < 0) return;
        var spellId = (uint)id;
        slot.Add(new Spell { Id = spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
