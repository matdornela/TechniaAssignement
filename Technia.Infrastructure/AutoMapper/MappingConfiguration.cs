using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Technia.Infrastructure.AutoMapper
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PresentationProfile());
            });

            return config;
        }
    }
}
