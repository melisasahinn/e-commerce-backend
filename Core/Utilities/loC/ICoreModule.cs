using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.loC
{
    public interface ICoreModule //Framework katmanı 
    {
        void Load(IServiceCollection serviceCollection);
    }
}
