using ApiWritter.Models;

namespace ApiWritter.Interfaces
{
    public interface IWriterRepository
    {
        IEnumerable<Writer> GetAll();

        Writer? GetById(int id);

        Writer Insert(Writer writer);
    }
}
