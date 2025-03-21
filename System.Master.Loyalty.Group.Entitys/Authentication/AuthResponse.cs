﻿namespace System.Master.Loyalty.Group.Entities.Authentication
{
    public class AuthResponse : BaseResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;
    }

}
