namespace MDCDataService
{
    public interface IProcess
    {
        void Run(string address, int port);
        void End();
    }
}
