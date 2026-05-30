namespace 嗨呀.舞者;

public class 舞者_EventControl : IRotationEventHandler
{
    public void OnPreCombat()
    {
    }

    public void OnResetBattle()
    {
        舞者_BattleData.Instance.Reset();
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
        var bd = 舞者_BattleData.Instance;
        bd.前一能力技 = spell.Id;
    }

    public void OnBattleUpdate(int battleTimeMs)
    {
        var bd = 舞者_BattleData.Instance;
        var self = Data.Me.Object;
        if (self == null) return;

        if ((self as IBattleChara)?.CurrentHp <= self.MaxHp * 0.4f)
            bd.需应急治疗 = true;
        else
            bd.需应急治疗 = false;
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的舞者ACR");
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
