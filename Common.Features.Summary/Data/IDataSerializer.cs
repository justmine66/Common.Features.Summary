using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary.Data
{
    public interface IDataSerializer<TModel>
    {
        byte[] Serialize(TModel model);
        TModel Deserialize(byte[] data);
    }
}
