using System;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper.Collection.EntityFrameworkCore.Tests
{
    public class EntityFramworkCoreUsingCtorTests : EntityFramworkCoreTestsBase
    {
        private IMapper _mapper;

        public EntityFramworkCoreUsingCtorTests()
        {
            var mapperConfigure = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>().ReverseMap();
                x.UseEntityFrameworkCoreModel<DB>();
            });

            _mapper = mapperConfigure.CreateMapper();
        }

        protected override DBContextBase GetDbContext()
        {
            return new DB();
        }

        protected override IMapper GetMapper()
        {
            return _mapper;
        }

        public class DB : DBContextBase
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("EfTestDatabase" + Guid.NewGuid());
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
