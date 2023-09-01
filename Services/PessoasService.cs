using ApiHexagon.Db;
using Microsoft.EntityFrameworkCore;


namespace ApiHexagon.Services
{
    public class PessoaService
    {
        private readonly MeuDbContext _context;

        public PessoaService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<int> CreatePessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa.Id;
        }

        public async Task UpdatePessoaAsync(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                throw new ArgumentException("IDs não coincidem.");
            }

            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoaAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }

        public bool PessoaExists(int id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
