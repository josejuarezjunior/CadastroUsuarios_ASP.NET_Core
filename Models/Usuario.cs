using System.Collections.Generic;
using System.Linq;

namespace UsandoViews.Models
{
	public class Usuario
	{
		public int IdUsuario { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		
		private static List<Usuario> listagem = new List<Usuario>();
		
		// A interface IQueryable é útil quando você esta consultando uma coleção que foi carregada usando 
		// LINQ ou Entity Framework e você quer aplicar um filtro nesta coleção.
		public static IQueryable<Usuario> Listagem
		{
			get
			{
				return listagem.AsQueryable();
			}
		}
		
		static Usuario()
		{
			Usuario.listagem.Add(new Usuario{IdUsuario = 1, Nome = "Eddard Stark", Email = "Ned@outlook.com"});
			Usuario.listagem.Add(new Usuario{IdUsuario = 2, Nome = "Daenerys Targaryen", Email = "Danny@outlook.com"});
			Usuario.listagem.Add(new Usuario{IdUsuario = 3, Nome = "Tyrion Lannister", Email = "tyrion@outlook.com"});
			Usuario.listagem.Add(new Usuario{IdUsuario = 4, Nome = "Robert Baratheon", Email = "bob@outlook.com"});
			Usuario.listagem.Add(new Usuario{IdUsuario = 5, Nome = "Jon Snow", Email = "jon@outlook.com"});
		}
		
		public static void Salvar(Usuario usuario)
		{
			var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
			if (usuarioExistente != null)
			{
				usuarioExistente.Nome = usuario.Nome;
				usuarioExistente.Email = usuario.Email;
			}
			else
			{ 
				int maiorId = Usuario.listagem.Max(u => u.IdUsuario);
				usuario.IdUsuario = maiorId + 1;
				Usuario.listagem.Add(usuario);
			}
		}
		
		public static void Excluir(int IdUsuario)
		{
			var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == IdUsuario);
			if (usuarioExistente != null)
			{
				Usuario.listagem.Remove(usuarioExistente);
			}
			
		}
	}	
}