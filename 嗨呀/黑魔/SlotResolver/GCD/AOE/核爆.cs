using 嗨呀.黑魔.SlotResolver.BLMData;
using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔.SlotResolver.GCD.AOE;

public class 核爆 : ISlotResolver
{
    public int Check()
    {
        if (GameHelper.GetCurrentLevel() < 50) return (int)CheckResult.等级不足;
        
        if (Data.Me.Object?.CurrentMp < 800) return (int)CheckResult.资源不足;
        
        if (!BLMHelper.火状态) return (int)CheckResult.状态不符;

        if (Data.Me.IsMoving && !BLMHelper.可瞬发) return (int)CheckResult.移动中;

        if (Data.Me.CurrentLevel >= 100 && BLMHelper.耀星层数 >= 3 && BLMHelper.耀星层数 < 6 &&
            !BLMHelper.群怪模式)
        {
            var bd = BLM_BattleData.Instance;
            if (!bd.能六火四)
            {
                var fire4Cost = BLMHelper.冰针数 > 0 ? 800 : 1600;
                if (Data.Me.Object?.CurrentMp < fire4Cost + 800)
                    return (int)BLMHelper.核爆;
            }
            else if (Data.Me.Object?.CurrentMp < 3200)
            {
                return (int)BLMHelper.核爆;
            }
        }
        
        if (!QTHelper.IsEnabled(QTKey.AOE)) return (int)CheckResult.QT关闭;

        if (!BLMHelper.群怪模式) return (int)CheckResult.群怪模式;
        
        return (int)BLMHelper.核爆;
    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell { Id = BLMHelper.核爆, TargetType = SpellTargetType.Target, Type = SpellType.RealGcd });
    }
}
