namespace TL.PMEUMAX_PC_1700.Driver
{
    internal interface IPneumaxDriver
    {
        IResponse SendCommand(ICommandSender sender, IMessage message);
    }
}