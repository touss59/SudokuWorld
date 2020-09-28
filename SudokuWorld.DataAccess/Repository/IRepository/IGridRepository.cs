using SudokuWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWorld.DataAccess.Repository.IRepository
{
    public interface IGridRepository : IRepository<Grid>
    {
        void Update(Grid grid);
    }
}
