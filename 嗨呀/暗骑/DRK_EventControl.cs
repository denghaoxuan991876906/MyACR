using HiAuRo.Helper;

namespace 嗨呀.暗骑;

public class DRK_EventControl : IRotationEventHandler
{
    public void OnPreCombat()
    {
    }

    public void OnResetBattle()
    {
        DRK_BattleData.Instance.Reset();
    }

    public void OnNoTarget()
    {
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
    }

    public Slot? BeforeSpell(Slot slot)
    {
        return null;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        var bd = DRK_BattleData.Instance;

        if (bd.AfterSpell.Count > 40)
            bd.AfterSpell.Clear();
        bd.AfterSpell.Add(spell.Id);

        if (spell.Type == SpellType.RealGcd)
            bd.前一gcd = spell.Id;
        else if (spell.Type == SpellType.Ability)
            bd.前一能力技 = spell.Id;

        if (spell.Id == DRKHelper.血乱)
            bd.使用血乱次数 = !bd.使用血乱次数;
    }

    public void OnBattleUpdate(int battleTimeMs)
    {
        var bd = DRK_BattleData.Instance;

        if (DRKHelper.血乱激活 || DRKHelper.嗜血激活)
        {
            if (bd.爆发开始时间 == 0)
                bd.爆发开始时间 = battleTimeMs;
        }
        else
        {
            if (bd.爆发开始时间 > 0 && battleTimeMs - bd.爆发开始时间 > 15000)
            {
                bd.爆发开始时间 = 0;
                bd.使用血乱次数 = false;
            }
        }
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的暗骑ACR");
    }

    public void OnExitRotation()
    {
    }

    public void OnTerritoryChanged()
    {
    }

    public void OnGameEvent(ITriggerCondParams eventParams)
    {
    }

    public void OnPhaseChanged(string phaseId, string phaseName)
    {
    }
}
