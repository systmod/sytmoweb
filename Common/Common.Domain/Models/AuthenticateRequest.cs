using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Domain.Models
{
    
    public class LoginRequest : AuthenticationRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Clave { get; set; }
    }

    public class AuthorizationRequest
    {
        [Required]
        public int IdUnidadAdmin { get; set; }
    }

    public class AuthenticationRequest
    {
        [Required]
        public string AppId { get; set; }

        [Required]
        public string DeviceId { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }
    } 

    public class ConfirmPasswordResponse
    {
        [Required]
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        [Required]
          public string Clave { get; set; }
  }

    public class ResetPasswordRequest
    {
        [Required]
        public string Usuario { get; set; }
    }

    public class ChangeEmailRequest
    {
        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Correo { get; set; }
    }

    public class ChangePasswordRequest
    { 
        [Required]
        public string Clave { get; set; }
    }

    public class ResetPasswordResponse
    { 
        public string Token { get; set; }
    }


    public class UserRegisterRequest
    {

        [Required]
        [StringLength(20)]
        public string Identificacion { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string Apellidos { get; set; }
        
        public string RazonSocial => $"{Nombres} {Apellidos}";

        [Required]
        [StringLength(500)]
        public string Correo { get; set; }

        public string Celular { get; set; }

        public string Foto { get; set; }

    }


    public class AuthorizationResponse : AuthenticationResponse
    {
        public string Perfil { get; set; }
        public int IdPerfil { get; set; }
        public ICollection<IModuleEntity> Permisos { get; set; }

        public AuthorizationResponse(IUserEntity user, IProfileEntity profile, string token)
            : base(user, token)
        {
            this.Perfil = profile.Descripcion;
            this.IdPerfil = profile.IdPerfil;
            this.Permisos = profile.Permisos;
        }
    }

    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Alias { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(IUserEntity user, string token)
        {
            Id = user.Identificacion;
            Nombre = user.Nombre;
            Alias = user.InicioSesion;
            Correo = user.Correo;

            Token = token;
        }
    }

    public class RegisterDeviceRequest
    {
        [Required]
        public string Usuario { get; set; }
    }
}
