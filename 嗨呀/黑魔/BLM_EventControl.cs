using 嗨呀.黑魔.UI;

namespace 嗨呀.黑魔;

public class BLM_EventControl : IRotationEventHandler
{
    private int _释放技能时状态;
    private readonly HashSet<string> _printedCallbacks = [];
    private readonly HashSet<Type> _printedEventTypes = [];



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
        var bd = BLM_BattleData.Instance;
        if (spell.Id is BLMHelper.冰澈)
        {
            bd.高级循环_冰澈读条完成 = true;
        }
    }

    public Slot? BeforeSpell(Slot slot)
    {
        return null;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        var bd = BLM_BattleData.Instance;
        var 释放前gcd = bd.前一gcd;
        var 释放前能力技 = bd.前一能力技;
        var 是黑魔Gcd = spell.Id is BLMHelper.火炎 or BLMHelper.爆炎 or BLMHelper.炽焰 or BLMHelper.烈炎 or BLMHelper.高烈炎
            or BLMHelper.绝望 or BLMHelper.核爆 or BLMHelper.耀星 or BLMHelper.悖论
            or BLMHelper.崩溃 or BLMHelper.异言 or BLMHelper.秽浊
            or BLMHelper.闪雷 or BLMHelper.暴雷 or BLMHelper.高闪雷
            or BLMHelper.震雷 or BLMHelper.霹雷 or BLMHelper.高震雷
            or BLMHelper.冰结 or BLMHelper.冰封 or BLMHelper.冰澈 or BLMHelper.玄冰
            or BLMHelper.高冰冻 or BLMHelper.冰冻 or BLMHelper.灵极魂;
        var 是黑魔能力技 = spell.Id is BLMHelper.即可咏唱 or BLMHelper.三连咏唱 or BLMHelper.星灵移位
            or BLMHelper.魔泉 or BLMHelper.详述 or BLMHelper.黑魔纹 or BLMHelper.醒梦 or BLMHelper.昏乱;

        if (bd.AfterSpell.Count > 40)
            bd.AfterSpell.Clear();
        bd.AfterSpell.Add(spell.Id);

        if (spell.Id is BLMHelper.魔泉)
        {
            bd.已回复蓝量 += 10000;
            bd.能六火四 = true;
            bd.火阶段已放炽焰数 = 0;
            bd.火阶段已放耀星 = false;
            bd.魔泉后待首个Gcd = true;
        }

        if (spell.Id is BLMHelper.星灵移位)
        {
            bd.已回复蓝量 = 0;
            if (BLMHelper.冰针数 == 3)
                bd.三冰针进冰 = true;
        }

        if (spell.Id is BLMHelper.冰澈 or BLMHelper.玄冰 or BLMHelper.冰冻 or BLMHelper.冰封)
        {
            if (bd.AfterSpell.FindLastIndex(id => id is BLMHelper.冰封 or BLMHelper.高冰冻 or BLMHelper.冰冻) >= 0)
                bd.已回复蓝量 += 10000;
            else
                bd.已回复蓝量 += 2500;
        }

        if (spell.Id is BLMHelper.耀星)
            bd.火阶段已放耀星 = true;

        if (spell.Id is BLMHelper.冰澈)
        {
            bd.冰阶段已放冰澈 = true;
            bd.三冰针进冰 = false;
        }

        if (spell.Id is BLMHelper.炽焰)
            bd.火阶段已放炽焰数++;

        if (bd.魔泉后待首个Gcd && spell.Id is BLMHelper.爆炎 or BLMHelper.炽焰 or BLMHelper.悖论
                or BLMHelper.核爆 or BLMHelper.绝望 or BLMHelper.耀星)
            bd.魔泉后待首个Gcd = false;

        if (spell.Id is BLMHelper.冰封 or BLMHelper.高冰冻 or BLMHelper.冰冻)
        {
            if (_释放技能时状态 == 2)
                bd.已回复蓝量 += 2500;
        }

        if (是黑魔Gcd)
        {
            bd.前一gcd = spell.Id;
            var 固有瞬发 = spell.Id is BLMHelper.悖论 or BLMHelper.异言 or BLMHelper.秽浊
                or BLMHelper.高闪雷 or BLMHelper.高震雷 or BLMHelper.暴雷 or BLMHelper.霹雷
                or BLMHelper.闪雷 or BLMHelper.震雷
                || (spell.Id == BLMHelper.绝望 && GameHelper.GetCurrentLevel() >= 100);
            bd.上一gcd瞬发 = 固有瞬发 || bd.下个gcd将瞬发;
            bd.下个gcd将瞬发 = false;
            bd.已使用瞬发 = GameHelper.GetGCDCooldown() >= 1500;
            if (BLMHelper.冰状态) _释放技能时状态 = 1;
            else if (BLMHelper.火状态) _释放技能时状态 = 2;
            else _释放技能时状态 = 0;
        }

        if (是黑魔能力技)
        {
            bd.前一能力技 = spell.Id;
        }



        // // 高级循环流程追踪：冰澈(读条)→星灵→绝望
        // if (QTHelper.IsEnabled(QTKey.高级循环))
        // {
        //     if (spell.Id is BLMHelper.星灵移位 && bd.高级循环_冰澈读条完成
        //                     && 释放前gcd == bd.高级循环_读条冰澈Gcd)
        //     {
        //         Hi.Debug($"[高级循环追踪] 星灵完成分支 释放前gcd={释放前gcd} 释放前能力={释放前能力技} 读条冰澈Gcd={bd.高级循环_读条冰澈Gcd} 冰澈读条完成={bd.高级循环_冰澈读条完成} 星灵已完成={bd.高级循环_星灵已完成}");
        //         bd.高级循环_冰澈读条完成 = false;
        //         bd.高级循环_星灵已完成 = true;
        //     }
        //     else if (spell.Id is BLMHelper.绝望 && bd.高级循环_星灵已完成
        //         && 释放前能力技 == BLMHelper.星灵移位
        //         && 释放前gcd == bd.高级循环_读条冰澈Gcd)
        //     {
        //         Hi.Debug($"[高级循环追踪] 绝望收尾分支 释放前gcd={释放前gcd} 释放前能力={释放前能力技} 读条冰澈Gcd={bd.高级循环_读条冰澈Gcd} 冰澈读条完成={bd.高级循环_冰澈读条完成} 星灵已完成={bd.高级循环_星灵已完成}");
        //         bd.高级循环_星灵已完成 = false;
        //         bd.高级循环_读条冰澈Gcd = 0;
        //     }
        //     else if ((是黑魔Gcd || 是黑魔能力技)
        //         && (bd.高级循环_冰澈读条完成 || bd.高级循环_星灵已完成))
        //     {
        //         Hi.Debug($"[高级循环追踪] 兜底清空分支 spell={spell.Id} 释放前gcd={释放前gcd} 释放前能力={释放前能力技} 读条冰澈Gcd={bd.高级循环_读条冰澈Gcd} 冰澈读条完成={bd.高级循环_冰澈读条完成} 星灵已完成={bd.高级循环_星灵已完成}");
        //         bd.高级循环_冰澈读条完成 = false;
        //         bd.高级循环_星灵已完成 = false;
        //         bd.高级循环_读条冰澈Gcd = 0;
        //     }
        // }
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
                bd.魔泉后待首个Gcd = false;
            }

            if (bd.上次冰火状态 == 1 && status == 2)
            {
                var startMP = Math.Min(bd.已回复蓝量, 10000);
                var ice = (int)BLMHelper.冰针数;
                var mpForSix = Math.Min(6, ice) * 800 + Math.Max(0, 6 - ice) * 1600;
                bd.能六火四 = startMP >= mpForSix + 800;
            }

            if (status == 1)
                bd.冰阶段已放冰澈 = false;

            if (status == 2)
            {
                bd.火阶段已放炽焰数 = 0;
                bd.需要三连 = false;
                bd.魔泉后待首个Gcd = false;
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

        if (!QTHelper.IsEnabled(QTKey.高级循环))
        {
            bd.高级循环_冰澈读条完成 = false;
            bd.高级循环_星灵已完成 = false;
            bd.高级循环_读条冰澈Gcd = 0;
        }

        // 满状态火阶段：预算到冰三时间 / 即刻能否转好 / 是否需要三连
        if (BLMHelper.火状态 && bd.能六火四)
        {
            var n = bd.火阶段已放炽焰数;
            var 剩余火4 = Math.Max(0, 6 - n);
            var 悖论 = (QTHelper.IsEnabled(QTKey.火悖论) && BLMHelper.悖论指示) ? 1 : 0;
            var 耀星 = (!bd.火阶段已放耀星 && BLMHelper.耀星层数 + 剩余火4 >= 6) ? 1 : 0;
            var gcdCount = 剩余火4 + 悖论 + 1 + 耀星 + 1; // +1绝望 +耀星(届时满6层) +1冰三
            bd.到冰三预估时间 = gcdCount * GCDHelper.GetGCDDuration();
            bd.即刻能转好 = SpellHelper.GetCooldownRemaining(BLMHelper.即可咏唱) < bd.到冰三预估时间;
            if (n == 4)
                bd.需要三连 = !bd.即刻能转好;
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
