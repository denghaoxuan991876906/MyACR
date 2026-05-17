using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.GCD;

public class AOE连击 : ISlotResolver
{
    private uint _spellId;

    public int Check()
    {
        if (HelperRuntime.GetCurrentLevel() < 15) return (int)CheckResult.等级不足;

        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!DRGHelper.群怪模式) return (int)CheckResult.群怪模式;

        var level = HelperRuntime.GetCurrentLevel();
        var lastCombo = ComboHelper.LastComboSpellId;

        if (lastCombo == DRGHelper.山境酷刑 && level >= 72)
        {
            _spellId = DRGHelper.龙眼苍穹;
            return 800 + (int)_spellId;
        }

        if (lastCombo == DRGHelper.音速刺 && level >= 60)
        {
            _spellId = DRGHelper.山境酷刑;
            return 700 + (int)_spellId;
        }

        if (lastCombo == DRGHelper.死天枪 && level >= 56)
        {
            _spellId = DRGHelper.音速刺;
            return 600 + (int)_spellId;
        }

        _spellId = DRGHelper.死天枪;
        return 500 + (int)_spellId;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
