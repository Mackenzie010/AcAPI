namespace AcAPI.DTL
{
    public class LabDTO
    {
        public int Id { get; set; }

        public int Andar { get; set; }

        public string Lab { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public DateOnly Dt_Cadastro { get; set; }

    }
}
