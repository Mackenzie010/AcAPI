namespace AcAPI.DAL
{
    public interface IRickDAO
    {
        Task<string> post(string boleto, int user_id);
        
    }
}
