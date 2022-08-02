﻿using ProjectEntra21.src.Domain.Entiteis;
using ProjectEntra21.src.Infrastructure.Database.Common;

namespace ProjectEntra21.src.Application.Database
{
    public interface ICellEmployeerRepository : IBaseRepository<CellEmployeer>
    {
        public bool ValidationCodeCell(int? codeCell);
        public bool ValidationRegisterEmployeer(long? registerEmployeer);
    }
}