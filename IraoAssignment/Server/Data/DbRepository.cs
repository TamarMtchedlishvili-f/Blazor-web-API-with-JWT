// using System.Linq;
// using IraoAssignment.Shared;
//
// namespace IraoAssignment.Server.Data
// {
//     public class DBRepository : IMarketAndCompanyRepository
//     {
//         private readonly ApplicationDbContext _db;
//
//         public DBRepository(ApplicationDbContext db)
//         {
//             _db = db;
//         }
//
//         public IQueryable<Market> Markets => _db.Markets;
//         public IQueryable<Company> Companies => _db.Companies;
//
//         public void Add<EntityType>(EntityType entity) => _db.Add(entity);
//         public void SaveChanges() => _db.SaveChanges();
//     }
// }