using DomainModel;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public class AutorizationResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserDTO? User { get; set; } = null;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
