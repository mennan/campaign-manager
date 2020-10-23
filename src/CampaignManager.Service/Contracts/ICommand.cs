namespace CampaignManager.Service
{
    public interface ICommand
    {
        string Execute(params object[] parameters);
    }
}