using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWorld.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGridRepository Grid { get; }
        ISP_Call SP_Call { get; }
    }
}
