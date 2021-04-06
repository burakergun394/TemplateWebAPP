using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class LogoDto: IDto
    {
        public string LogoPath { get; set; }
    }
}
