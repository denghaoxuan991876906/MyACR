namespace 嗨呀.绝枪.UI;

public class GNBRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);

        builder.AddQtToggle(QTKey.无情, true);
        builder.AddQtToggle(QTKey.子弹连, true);
        builder.AddQtToggle(QTKey.爆发击, true);
        builder.AddQtToggle(QTKey.倍功, true);
        builder.AddQtToggle(QTKey.血壤, true);
        builder.AddQtToggle(QTKey.续剑, true);
        builder.AddQtToggle(QTKey.音速破, true);
        builder.AddQtToggle(QTKey.弓形冲波, true);
        builder.AddQtToggle(QTKey.爆破领域,  true);
        builder.AddQtToggle(QTKey.血壤连, true);
    }
}
