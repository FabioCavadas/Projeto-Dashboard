using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        private readonly DataContext dataContext;

        public ContaRepository(DataContext dataContext) : base(dataContext) { this.dataContext = dataContext; }

        public override List<Conta> GetAll()
        {
            return dataContext.Contas.OrderByDescending(c => c.DataConta).ToList();
        }

        public List<Conta> GetByDatas(DateTime dataMin, DateTime dataMax) { return dataContext.Contas.Where(c => c.DataConta >= dataMin && c.DataConta <= dataMax).OrderByDescending(c => c.DataConta).ToList(); }
    }
}
