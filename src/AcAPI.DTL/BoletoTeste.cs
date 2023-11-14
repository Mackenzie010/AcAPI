namespace AcAPI.DTL
{
    public class DataTeste
    {
        public BoletoTeste data { get; set; }
    }
    public class BoletoTeste
    {
        public string boleto { get; set; }
        public int user_id { get; set; }
        public DateTime payment_date { get; set; }
        public string status { get; set; }
    }
}