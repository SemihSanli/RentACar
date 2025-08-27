using CQRS_MediatR_RentACar.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.DataAccessLayer.Abstract
{
    public interface IContactDal:IGenericDal<Contact>
    {
    }
}
