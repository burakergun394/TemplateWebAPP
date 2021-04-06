using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class GeneralInformation: IEntity
    {
        public int Id { get; set; }
        public string LogoPath { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string GoogleMapAddress { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
    }
}
