// Check() 返回值约定：
//   >= 0   = 可用，优先级由 BLM_ACR_Entry.cs 中 SlotResolvers 的排列顺序决定
//    < 0   = 拒绝，该值仅作为调试标签

namespace 嗨呀.黑魔.SlotResolver.BLMData;

public enum CheckResult
{
    等级不足 = -100,
    技能未解锁 = -77,
    移动中 = -99,
    群怪模式 = -234,
    技能未就绪 = -1,
    冷却中 = -2,
    资源不足 = -3,
    QT关闭 = -4,
    状态不符 = -5,
    特殊循环中 = -6,
    目标无效 = -7,
    最近已用 = -8,
}
