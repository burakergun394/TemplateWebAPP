using Core.DataAccess.Concrete.Entityframework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Entityframework
{
    public class EfGeneralInformationDal : EfEntityRepositoryBase<GeneralInformation, DenemeContext>, IGeneralInformationDal
    {
    }
}