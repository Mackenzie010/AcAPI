namespace AcAPI.DTL
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly Birthday { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }

        public string Password { get; set; }
    }
}