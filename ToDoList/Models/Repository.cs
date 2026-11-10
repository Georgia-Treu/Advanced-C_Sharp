using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class Repository<T> where T : class
    {
        protected TicketContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(TicketContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> List()
        {
            return dbset.ToList();
        }

        public virtual T? Get(int id) => dbset.Find(id);
        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Save() => context.SaveChanges();

    }
}
