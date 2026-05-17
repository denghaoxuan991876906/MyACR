using 嗨呀.舞者.SlotResolver.DNCData;
using 嗨呀.舞者.UI;

namespace 嗨呀.舞者.SlotResolver.GCD;

public class 基础连击 : ISlotResolver
{
    public int Check()
    {
        if (DNCHelper.IsDancing) return (int)CheckResult.状态不符;

        if (QTHelper.IsEnabled(QTKey.AOE) && DNCHelper.双目标)
        {
            if (ComboHelper.LastComboSpellId == DNCHelper.风车)
                return (int)DNCHelper.落刃雨;
            return (int)DNCHelper.风车;
        }

        if (ComboHelper.LastComboSpellId == DNCHelper.瀑泻)
            return (int)DNCHelper.喷泉;
        return (int)DNCHelper.瀑泻;
    }

    public void Build(Slot slot)
    {
        var id = (uint)Check();
        slot.Add(new Spell { Id = id, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
