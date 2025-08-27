using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.EntityLayer
{
    public class Statistic
    {
        public int StatisticID { get; set; }
        public string StatisticIcon { get; set; }
        public string StatisticTitle { get; set; }
        public string StaticScore { get; set; }
    }
}
