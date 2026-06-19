using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 火单100 : ISlotResolver
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
        var 火四成本 = BLMHelper.冰针数 > 0 ? 800u : 1600u;
        var 有火悖论 = BLMHelper.悖论指示 && QTHelper.IsEnabled(QTKey.火悖论);
        var 绝望阈值 = QTHelper.IsEnabled(QTKey.火悖论) ? 2400u : 4000u;
        var 耀星层数 = (uint)Math.Max(0, BLMHelper.耀星层数);
        var 冰针数 = BLMHelper.冰针数;

        // 无火无冰：高蓝直接进火，低蓝先进冰恢复
        if (!BLMHelper.火状态 && !BLMHelper.冰状态)
        {
            if (mp >= 6600) return BLMHelper.爆炎;
            return 0;
        }

        if (BLMHelper.冰状态 || !BLMHelper.火状态)
            return 0;

        // 火层未满
        if (BLMHelper.火层数 < 3)
        {
            if (BLMHelper.Has火苗) return BLMHelper.爆炎;
            if (BLMHelper.悖论指示 && mp >= 2400) return BLMHelper.悖论;
        }

        if (!BLM_BattleData.在正常火阶段())
            return 0;

        // 正常火阶段固定顺序：耀星 -> 火悖论 -> 绝望/炽焰
        if (耀星层数 == 6)
            return BLMHelper.耀星;

        if (有火悖论 && mp >= 2400 && mp <= 3000)
            return BLMHelper.悖论;

        var 纯炽焰补满所需蓝量 = 计算补满耀星所需蓝量(耀星层数, 冰针数);
        var 可以正常补满耀星 = bd.火阶段已放耀星 || mp >= 纯炽焰补满所需蓝量;

        if (!可以正常补满耀星)
        {
            // 还没到3层且无冰针时，如果蓝量已经不够再靠炽焰把层数推到3，直接绝望收火。
            if (mp < 2400 && 冰针数 < 1 && mp >= 800 && 耀星层数 < 3)
                return BLMHelper.绝望;

            // 到了3层后，优先按 QT 决定是否插火悖论，再用核爆一次补3层。
            if (耀星层数 >= 3)
            {
                if (有火悖论 && mp >= 2400)
                    return BLMHelper.悖论;

                if (mp >= 800)
                    return BLMHelper.核爆;

                return 0;
            }

            // 还没到3层，继续用炽焰把层数补到3层。
            if (mp >= 火四成本)
                return BLMHelper.炽焰;

            if (mp >= 800)
                return BLMHelper.绝望;

            return 0;
        }

        if (mp >= 800)
        {
            if (mp < 绝望阈值 && BLMHelper.耀星层数 < 5)
                return BLMHelper.绝望;

            if (mp >= 火四成本)
                return BLMHelper.炽焰;
        }

        return 0;
    }

    private static uint 计算补满耀星所需蓝量(uint 当前耀星层数, uint 当前冰针数)
    {
        if (当前耀星层数 >= 6) return 0;

        var 剩余层数 = 6u - 当前耀星层数;
        var 冰针减耗次数 = Math.Min(剩余层数, 当前冰针数);
        var 常规耗蓝次数 = 剩余层数 - 冰针减耗次数;
        return 冰针减耗次数 * 800u + 常规耗蓝次数 * 1600u;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = _skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
