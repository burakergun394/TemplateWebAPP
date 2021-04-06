using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class SocialMediaDto: IDto
    {
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
    }
}
