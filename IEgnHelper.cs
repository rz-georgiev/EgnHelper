namespace EgnHelper
{
    public interface IEgnHelper
    {
        /// <summary>
        /// Retruns basic bulgarian citizen information using the specified EGN
        /// </summary>
        EgnData GetEgnData(string egn);
    }
}