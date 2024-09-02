using Autofac;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.AutomapperProfiles;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LibraryContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<BookManager>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBookDal>().As<IBookDal>().InstancePerLifetimeScope();

            builder.RegisterType<GenreManager>().As<IGenreService>().InstancePerLifetimeScope();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>().InstancePerLifetimeScope();

            builder.RegisterType<AuthorManager>().As<IAuthorService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            })).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
