using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsShow { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
    }
}
