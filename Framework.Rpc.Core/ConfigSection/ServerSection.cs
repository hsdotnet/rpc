namespace Framework.Rpc.Core.ConfigSection
{
    public class ServerSection : BaseSection
    {
        public string AppName { get; set; }

        public int Port { get; set; }

        public string ServiceDLL { get; set; }
    }
}