using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Abstractions.Storage
{
    public interface IStorageService: IStorage
    {
        public string StorageName { get; }
    }
}
