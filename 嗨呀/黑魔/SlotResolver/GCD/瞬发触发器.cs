using 嗨呀.黑魔.SlotResolver.BLMData;

namespace 嗨呀.黑魔.SlotResolver.GCD;

public class 瞬发触发器 : ISlotResolver
{
    public int Check()
    {
        if (!BLM_BattleData.Instance.需要瞬发gcd) return (int)CheckResult.状态不符;

        if (BLMHelper.可瞬发) return (int)CheckResult.状态不符;

        if (!BLM_BattleData.在发呆()) return (int)CheckResult.状态不符;

        var skillId = 可用瞬发();
        if (skillId < 0) return (int)CheckResult.技能未就绪;

        return skillId;
    }

    public void Build(Slot slot)
    {
        BLM_BattleData.Instance.需要瞬发gcd = false;

        var skillId = 可用瞬发();
        if (skillId > 0)
            slot.Add(new Spell { Id = (uint)skillId, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }

    private static int 可用瞬发()
    {
        var level = HelperRuntime.GetCurrentLevel();
        if (BLMHelper.群怪模式)
        {
            if (BLMHelper.Has雷云 && BLMHelper.补dot())
            {
                var aoeThunder = level >= 92 ? BLMHelper.高震雷 : level >= 64 ? BLMHelper.霹雷 : BLMHelper.震雷;
                return (int)HelperRuntime.GetActionChange(aoeThunder);
            }

            if (BLMHelper.火状态 && BLMHelper.Has火苗 && BLMHelper.火层数 < 3)
                return (int)HelperRuntime.GetActionChange(BLMHelper.高烈炎);

            if (BLMHelper.火状态 && Data.Me.Object?.CurrentMp < 800)
                return (int)BLMHelper.核爆;

            if (BLMHelper.通晓数 > 0)
                return (int)BLMHelper.秽浊;

            if (BLMHelper.冰状态 && BLMHelper.冰层数 < 3)
                return (int)HelperRuntime.GetActionChange(BLMHelper.高冰冻);

            return -1;
        }

        if (BLMHelper.Has雷云 && BLMHelper.补dot())
        {
            var thunderId = level >= 92 ? BLMHelper.高闪雷 : level >= 45 ? BLMHelper.暴雷 : BLMHelper.闪雷;
            return (int)HelperRuntime.GetActionChange(thunderId);
        }

        if (BLMHelper.火状态 && BLMHelper.Has火苗 && BLMHelper.火层数 < 3)
            return (int)HelperRuntime.GetActionChange(BLMHelper.爆炎);

        if (BLMHelper.悖论指示)
            return (int)BLMHelper.悖论;

        if (BLMHelper.火状态)
        {
            var mp = Data.Me.Object?.CurrentMp;
            if (mp >= 800 && mp < 2400)
                return (int)BLMHelper.绝望;
        }

        if (BLMHelper.通晓数 > 0)
            return (int)BLMHelper.异言;

        if (BLMHelper.补dot() && level >= 45)
        {
            var thunderId = level >= 92 ? BLMHelper.高闪雷 : level >= 45 ? BLMHelper.暴雷 : BLMHelper.闪雷;
            return (int)HelperRuntime.GetActionChange(thunderId);
        }

        return -1;
    }
}
