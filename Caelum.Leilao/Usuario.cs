namespace Caelum.Leilao
{

    public class Usuario
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Usuario(string nome) : this(0, nome)
        {
        }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Usuario other = (Usuario)obj;
            if (Id != other.Id)
                return false;
            if (Nome == null)
            {
                if (other.Nome != null)
                    return false;
            }
            else if (!Nome.Equals(other.Nome))
                return false;
            return true;
        }
    }
}
