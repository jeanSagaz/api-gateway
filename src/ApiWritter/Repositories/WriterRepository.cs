using ApiWritter.Interfaces;
using ApiWritter.Models;

namespace ApiWritter.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly static List<Writer> _writers = Populate();

        private static List<Writer> Populate()
        {
            return new List<Writer>()
            {
                new Writer()
                {
                    Id = 1,
                    Name = "Machado de Assis"
                },
                new Writer()
                {
                    Id = 2,
                    Name = "Clarice Lispector"
                },
                new Writer()
                {
                    Id = 3,
                    Name = "Guimarães Rosa"
                },
                new Writer()
                {
                    Id = 4,
                    Name = "Carlos Drummond de Andrade"
                }
            };
        }

        public IEnumerable<Writer> GetAll() => _writers.ToList();

        public Writer? GetById(int id) => _writers.FirstOrDefault(x => x.Id == id);

        public Writer Insert(Writer writer)
        {
            _writers.Add(writer);

            return writer;
        }
    }
}
