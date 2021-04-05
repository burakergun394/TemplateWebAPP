using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Mapping.Automapper;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfServiceDal>().As<IServiceDal>().SingleInstance();
            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();

            builder.RegisterType<EfConstantDal>().As<IConstantDal>().SingleInstance();
            builder.RegisterType<ConstantManager>().As<IConstantService>().SingleInstance();
        }
    }
}
