using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoQuery.Domain
{
    public interface IRepository <T> where T : class
    {
        Result<IEnumerable<T>> Get();

        Result<T> Get(Guid id);

        Result<T> Create(T item);

        Result<IEnumerable<T>> Create(IEnumerable<T> items);

        Result<T> Update(T item);

        void Delete(Guid id);

    }
}
