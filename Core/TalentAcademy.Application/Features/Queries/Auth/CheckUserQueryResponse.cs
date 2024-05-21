﻿namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsExist { get; set; }
        public string? ErrorMessage { get; set; }
    }
}