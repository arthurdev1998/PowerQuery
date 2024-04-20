using System.Linq.Expressions;
using PowerQuery.Entities;
using PowerQuery.Interfaces.Repository;

namespace PowerQuery.Service.Usuarios;

public class UsuarioService
{
    private readonly IRepositoryBase<Usuario> _repositoryBase;

    public UsuarioService(IRepositoryBase<Usuario> repositorioBase)
    {
        _repositoryBase = repositorioBase;    
    }   

    public async Task<Usuario> GetById(int id)
    {
        // Func<Usuario, bool> Function = x => x.Id == id;
        // Expression<Func<Usuario, bool>> expression = x => Function(x);,

        Expression<Func<Usuario,bool>> expression = x => x.Id == id;

        return await  _repositoryBase.GetSomeThing(expression, true);
    }
}