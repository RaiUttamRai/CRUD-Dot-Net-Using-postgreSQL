using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Model.InfoViewModel
{
    public class InfoVM
    {
        public readonly int id;

        public Info? Info {  get; set; }
        public Detail? Detail { get; set; }
    }
}
