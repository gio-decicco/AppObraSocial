﻿namespace AppObraSocial.Models.Dtos
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;
        public virtual Plane IdPlanNavigation { get; set; } = null!;
    }
}
