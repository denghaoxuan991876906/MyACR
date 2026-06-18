namespace 嗨呀.黑魔;

public class BLM_EventControl : IRotationEventHandler
{
    private int _释放技能时状态;
    private readonly HashSet<string> _printedCallbacks = [];
    private readonly HashSet<Type> _printedEventTypes = [];

    private void PrintOnce(string callback)
    {
        if (_printedCallbacks.Add(callback))
            Hi.Print($"[{DateTime.Now:HH:mm:ss.fff}] {callback}");
    }

    public void OnPreCombat()
    {
    }

    public void OnResetBattle()
    {
        BLM_BattleData.Instance.Reset();
    }

    public void OnNoTarget()
    {
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
        PrintOnce($"OnSpellCastSuccess: {spell.Name} (Id={spell.Id})");
    }

    public Slot? BeforeSpell(Slot slot)
    {
        PrintOnce($"BeforeSpell: {slot.Actions[0]?.Spell.Name} (Id={slot.Actions[0]?.Spell.Id})");
        return null;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        var bd = BLM_BattleData.Instance;

        if (bd.AfterSpell.Count > 40)
            bd.AfterSpell.Clear();
        bd.AfterSpell.Add(spell.Id);

        if (spell.Id is BLMHelper.魔泉)
        {
            bd.已回复蓝量 += 10000;
            bd.能六火四 = true;
        }

        if (spell.Id is BLMHelper.星灵移位)
            bd.已回复蓝量 = 0;

        if (spell.Id is BLMHelper.冰澈 or BLMHelper.玄冰 or BLMHelper.冰冻 or BLMHelper.冰封)
        {
            if (bd.AfterSpell.FindLastIndex(id => id is BLMHelper.冰封 or BLMHelper.高冰冻 or BLMHelper.冰冻) >= 0)
                bd.已回复蓝量 += 10000;
            else
                bd.已回复蓝量 += 2500;
        }

        if (spell.Id is BLMHelper.耀星)
            bd.火阶段已放耀星 = true;

        if (spell.Id is BLMHelper.冰封 or BLMHelper.高冰冻 or BLMHelper.冰冻)
        {
            if (_释放技能时状态 == 2)
                bd.已回复蓝量 += 2500;
        }

        if (spell.Id is BLMHelper.火炎 or BLMHelper.爆炎 or BLMHelper.炽焰 or BLMHelper.烈炎 or BLMHelper.高烈炎
            or BLMHelper.绝望 or BLMHelper.核爆 or BLMHelper.耀星 or BLMHelper.悖论
            or BLMHelper.崩溃 or BLMHelper.异言 or BLMHelper.秽浊
            or BLMHelper.闪雷 or BLMHelper.暴雷 or BLMHelper.高闪雷
            or BLMHelper.震雷 or BLMHelper.霹雷 or BLMHelper.高震雷
            or BLMHelper.冰结 or BLMHelper.冰封 or BLMHelper.冰澈 or BLMHelper.玄冰
            or BLMHelper.高冰冻 or BLMHelper.冰冻 or BLMHelper.灵极魂)
        {
            bd.前一gcd = spell.Id;
            bd.已使用瞬发 = GameHelper.GetGCDCooldown() >= 1500;
            if (BLMHelper.冰状态) _释放技能时状态 = 1;
            else if (BLMHelper.火状态) _释放技能时状态 = 2;
            else _释放技能时状态 = 0;
        }

        if (spell.Id is BLMHelper.即可咏唱 or BLMHelper.三连咏唱 or BLMHelper.星灵移位
            or BLMHelper.魔泉 or BLMHelper.详述 or BLMHelper.黑魔纹 or BLMHelper.醒梦 or BLMHelper.昏乱)
        {
            bd.前一能力技 = spell.Id;
        }
    }

    public void OnBattleUpdate(int battleTimeMs)
    {
        var bd = BLM_BattleData.Instance;

        var status = BLMHelper.冰火状态();
        if (status != bd.上次冰火状态)
        {
            if (bd.上次冰火状态 == 2 && status == 1)
            {
                bd.AfterSpell.Clear();
                bd.已回复蓝量 = 0;
                bd.火阶段已放耀星 = false;
            }

            if (bd.上次冰火状态 == 1 && status == 2)
            {
                var startMP = Math.Min(bd.已回复蓝量, 10000);
                var ice = (int)BLMHelper.冰针数;
                var mpForSix = Math.Min(6, ice) * 800 + Math.Max(0, 6 - ice) * 1600;
                bd.能六火四 = startMP >= mpForSix + 800;
            }
            bd.上次冰火状态 = status;
        }

        if (BLMHelper.可瞬发)
            bd.需要即刻 = false;

        if (BLM_BattleData.在发呆())
        {
            if (bd.需要瞬发gcd)
                return;
            bd.需要即刻 = true;
        }

        if (Data.Me.Object?.IsCasting == true)
        {
            bd.需要即刻 = false;
            bd.已使用瞬发 = false;
            bd.需要瞬发gcd = false;
        }
    }

    public void OnEnterRotation()
    {
        Hi.Print("欢迎使用嗨呀的黑魔ACR");
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
