namespace 嗨呀.龙骑;

public class 龙骑_EventControl : IRotationEventHandler
{
    public void OnPreCombat()
    {
    }

    public void OnResetBattle()
    {
        龙骑_BattleData.Instance.Reset();
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
        var bd = 龙骑_BattleData.Instance;

        if (bd.AfterSpell.Count > 40)
            bd.AfterSpell.Clear();
        bd.AfterSpell.Add(spell.Id);

        if (spell.Id is DRGHelper.精准刺 or DRGHelper.贯穿刺 or DRGHelper.前冲刺
            or DRGHelper.直刺 or DRGHelper.苍穹刺 or DRGHelper.开膛枪 or DRGHelper.螺旋击
            or DRGHelper.樱花怒放 or DRGHelper.樱花缭乱 or DRGHelper.龙牙龙爪 or DRGHelper.龙尾大回旋
            or DRGHelper.云蒸龙变 or DRGHelper.死天枪 or DRGHelper.音速刺 or DRGHelper.山境酷刑
            or DRGHelper.龙眼苍穹 or DRGHelper.贯穿尖 or DRGHelper.龙眼雷电)
        {
            bd.前一gcd = spell.Id;
        }

        if (spell.Id is DRGHelper.猛枪 or DRGHelper.战斗连祷 or DRGHelper.跳跃 or DRGHelper.高跳
            or DRGHelper.龙剑 or DRGHelper.幻象冲 or DRGHelper.武神枪
            or DRGHelper.坠星冲 or DRGHelper.龙炎升 or DRGHelper.龙炎冲
            or DRGHelper.天龙点睛 or DRGHelper.死者之岸 or DRGHelper.渡星冲
            or DRGHelper.龙眼)
        {
            bd.前一能力技 = spell.Id;
        }
    }

    public void OnBattleUpdate(int battleTimeMs)
    {
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的龙骑ACR");
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
