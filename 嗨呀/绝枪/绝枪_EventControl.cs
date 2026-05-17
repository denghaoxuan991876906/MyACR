namespace 嗨呀.绝枪;

public class 绝枪_EventControl : IRotationEventHandler
{
    public void OnPreCombat()
    {
    }

    public void OnResetBattle()
    {
        绝枪_BattleData.Instance.Reset();
    }

    public void OnNoTarget()
    {
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
    }

    public void BeforeSpell(Slot slot, Spell spell)
    {
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        var bd = 绝枪_BattleData.Instance;

        if (bd.AfterSpell.Count > 40)
            bd.AfterSpell.Clear();
        bd.AfterSpell.Add(spell.Id);

        bd.无情中 = GNBHelper.Has无情;

        switch (spell.Id)
        {
            case GNBHelper.利刃斩:
                bd.基础连击步数 = 1;
                break;
            case GNBHelper.残暴弹技能:
                bd.基础连击步数 = 2;
                break;
            case GNBHelper.讯连斩:
                bd.基础连击步数 = 3;
                break;
            case GNBHelper.恶魔切:
                bd.基础连击步数 = 1;
                break;
            case GNBHelper.恶魔杀:
                bd.基础连击步数 = 2;
                break;
            case GNBHelper.烈牙:
                bd.子弹连步骤 = 1;
                break;
            case GNBHelper.猛兽爪:
                bd.子弹连步骤 = 2;
                break;
            case GNBHelper.凶禽爪:
                bd.子弹连步骤 = 3;
                break;
            case GNBHelper.崛起之心:
                bd.血壤连步骤 = 1;
                break;
            case GNBHelper.支配之心:
                bd.血壤连步骤 = 2;
                break;
            case GNBHelper.终结之心:
                bd.血壤连步骤 = 3;
                break;
        }

        if (spell.Id is GNBHelper.爆发击 or GNBHelper.命运之环 or GNBHelper.烈牙
            or GNBHelper.猛兽爪 or GNBHelper.凶禽爪)
        {
            bd.子弹数 = GNBHelper.CartridgeCount;
        }

        if (spell.Id is GNBHelper.爆发击 or GNBHelper.命运之环 or GNBHelper.烈牙
            or GNBHelper.猛兽爪 or GNBHelper.凶禽爪 or GNBHelper.无情)
        {
            bd.续剑 = GNBHelper.续剑激活;
        }
    }

    public void OnBattleUpdate(int battleTimeMs)
    {
        var bd = 绝枪_BattleData.Instance;
        bd.无情中 = GNBHelper.Has无情;
        bd.子弹数 = GNBHelper.CartridgeCount;
        bd.续剑 = GNBHelper.续剑激活;

        if (!GNBHelper.Has无情)
        {
            bd.子弹连步骤 = 0;
        }

        if (!GNBHelper.血壤激活 && !HelperRuntime.HasStatus(3840))
        {
            bd.血壤连步骤 = 0;
        }
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的绝枪ACR");
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
