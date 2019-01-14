namespace SeNegocia.Entity.Dto
{
    namespace EncargadoTicket
    {
        public class EncargadoTicketDTO : BaseSenegocia
        {
            public EncargadoTicketDTO(int id, string nombre)
                : base(id, nombre) { }

            public EncargadoTicketDTO()
                : base() { }
        }
    }
}
