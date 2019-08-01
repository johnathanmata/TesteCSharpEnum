namespace Teste.Entities
{
    class Departament
    {
        public string Name { get; set; }

        public Departament()
        {
        }
        public Departament(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "Departament: " + Name;
        }
    }
}
