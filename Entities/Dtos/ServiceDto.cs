using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class ServiceDto: IDto
    {
        public string Name { get; set; }
        public Boolean IsShow { get; set; }
    }
}
