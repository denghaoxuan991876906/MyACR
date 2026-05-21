using HiAuRo.Runtime;

namespace 嗨呀.黑魔.起手;

public class BLM_Open100 :IOpener
{
    public int StartCheck()
    {
        throw new NotImplementedException();
    }

    public int StopCheck(int index)
    {
        throw new NotImplementedException();
    }

    public List<Action<Slot>> Sequence { get; }
    public void InitCountDown(CountDownHandler handler)
    {
        throw new NotImplementedException();
    }

    public uint Level { get; }
}