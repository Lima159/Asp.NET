using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository.implementacoes
{
    public class EmprestimoRepository : GenericRepository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(BibliotecaContext context) : base(context) { }

        public async Task<int> GetDia(int data)
        {
            return await _context.Emprestimo
                .Where(emprestimo => emprestimo.Data_Emprestimo.Day == data)
                .CountAsync();
        }

        public async Task<int> GetMes(int data)
        {
            return await _context.Emprestimo
                .Where(emprestimo => emprestimo.Data_Emprestimo.Month == data)
                .CountAsync();
        }

        public override async Task<Emprestimo> FindById(int id)
        {
            return await _context.Emprestimo
                .SingleOrDefaultAsync(emprestimo => emprestimo.Id.Equals(id));
        }

        public async Task<Emprestimo> DevolucaoAtrasadaLeitor(int id)
        {
            return await _context.Emprestimo
                .Where(emprestimo => emprestimo.LeitorId.Equals(id))
                .Where(emprestimo => emprestimo.Data_Expiracao < emprestimo.Data_Devolucao)
                .LastOrDefaultAsync();
        }

        public async Task<int> GetDevolucaoAtrasada(int mes)
        {
            return await _context.Emprestimo
                .Where(emprestimo => emprestimo.Data_Emprestimo.Month.Equals(mes))
                .Where(emprestimo => emprestimo.Data_Expiracao < emprestimo.Data_Devolucao)
                .CountAsync();
        }
    }
}
