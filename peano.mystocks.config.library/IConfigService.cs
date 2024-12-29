using System;
using System.Collections.Generic;
using System.Text;

namespace peano.mystocks.config.library
{
    public interface IConfigService
    {
        void Save<T>(T data, string? elementName = null);

        T Load<T>(string? elementName = null);
    }
}
