using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.龙骑.UI;

namespace 嗨呀.龙骑.SlotResolver.GCD;

public class 基础连击 : ISlotResolver
{
    private uint _spellId;

    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 1) return (int)CheckResult.等级不足;

        if (QTHelper.IsEnabled(QTKey.AOE) && DRGHelper.群怪模式) return (int)CheckResult.群怪模式;

        var level = GameHelper.GetCurrentLevel();
        var lastCombo = ComboHelper.LastComboSpellId;

        if (DRGHelper.龙眼预备)
        {
            if (level >= 70 && CooldownHelper.GetCooldownRemaining(DRGHelper.龙眼雷电) <= 0)
            {
                _spellId = DRGHelper.龙眼雷电;
                return 1000 + (int)_spellId;
            }
        }

        if (level >= 96 && (lastCombo == DRGHelper.龙牙龙爪 || lastCombo == DRGHelper.龙尾大回旋))
        {
            _spellId = DRGHelper.云蒸龙变;
            return 900 + (int)_spellId;
        }

        if (lastCombo == DRGHelper.直刺 || lastCombo == DRGHelper.苍穹刺 ||
            lastCombo == DRGHelper.樱花怒放 || lastCombo == DRGHelper.樱花缭乱)
        {
            if (level >= 56)
            {
                _spellId = DRGHelper.龙牙龙爪;
                return 800 + (int)_spellId;
            }
        }

        if (lastCombo == DRGHelper.开膛枪 || lastCombo == DRGHelper.螺旋击)
        {
            if (level >= 38)
            {
                _spellId = level >= 62 ? DRGHelper.樱花缭乱 : DRGHelper.樱花怒放;
                return 700 + (int)_spellId;
            }
        }

        if (lastCombo == DRGHelper.贯穿刺 || lastCombo == DRGHelper.前冲刺)
        {
            if (level >= 6)
            {
                _spellId = level >= 62 ? DRGHelper.苍穹刺 : DRGHelper.直刺;
                return 700 + (int)_spellId;
            }
        }

        if (lastCombo == DRGHelper.精准刺)
        {
            if (DRGHelper.需要补DOT && level >= 25)
            {
                _spellId = level >= 74 ? DRGHelper.螺旋击 : DRGHelper.开膛枪;
                return 600 + (int)_spellId;
            }

            if (level >= 4)
            {
                _spellId = level >= 74 ? DRGHelper.前冲刺 : DRGHelper.贯穿刺;
                return 600 + (int)_spellId;
            }
        }

        _spellId = DRGHelper.精准刺;
        return 500 + (int)_spellId;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _spellId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
