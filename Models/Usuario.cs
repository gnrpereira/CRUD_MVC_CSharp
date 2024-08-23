namespace UsandoViews.Models
{
  public class Usuario
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    private static List<Usuario> listagem = new List<Usuario>();

    public static IQueryable<Usuario> Listagem
    {
      get { return listagem.AsQueryable();}
    }

    static Usuario()
    {
      Usuario.listagem.Add(
        new Usuario {Id = 1, Nome = "Fulano", Email = "fulano@email.com"});
      Usuario.listagem.Add(
        new Usuario {Id = 2, Nome = "Sicrano", Email = "Sicrano@email.com"});
      Usuario.listagem.Add(
        new Usuario {Id = 3, Nome = "Beltrano", Email = "beltrano@email.com"});
      Usuario.listagem.Add(
        new Usuario {Id = 4, Nome = "Maria", Email = "maria@email.com"});
    }

    public static void Salvar(Usuario usuario)
    {
      var usuarioExistente = listagem.Find(u => u.Id == usuario.Id);
      if(usuarioExistente != null)
      {
          usuarioExistente.Nome = usuario.Nome;
          usuarioExistente.Email = usuario.Email;
      }
      else
      {
          int maiorId = 0;
          if(Usuario.Listagem.Count() > 0)
          {
            maiorId = Usuario.Listagem.Max(u => u.Id);
            usuario.Id = maiorId + 1;
          }
      }
    }

    public static void Excluir(Usuario usuario)
    {
      var usuarioExistente = listagem.Find(u => u.Id == usuario.Id);
      if(usuarioExistente != null)
      {
          Usuario.listagem.Remove(usuarioExistente);
      }
    }
  }
}