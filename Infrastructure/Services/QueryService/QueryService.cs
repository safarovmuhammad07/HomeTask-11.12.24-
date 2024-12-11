using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services.QueryService;

public class QueryService : IQueryService
{
    private readonly DapperContext _context;

    public QueryService()
    {
        _context = new DapperContext();
    }

    public List<string> UserOfMarket()
    {
        var sql = @"select 'user : '||u.firstname||' '||u.lastname||' market : '||m.market_name
                   from users as u
                   join markets as m on u.id = m.userid;";
        
        var res = _context.Connection().Query<string>(sql).ToList();
        return res;
    }
    
    public List<string> ProductOfCategory()
    {
        var sql = @"select 'producte name : '||p.name||'  category : '||c.name
                    from products as p
                    join categories as c on c.id =p.categoryid;";
        var res = _context.Connection().Query<string>(sql).ToList();
        return res;
    }
    
    
    public class ProductService
    {
        private readonly DapperContext _context;

        public ProductService()
        {
            _context = new DapperContext();  
        }

        public List<CategoryRating> GetAverageRatingsByCategory()
        {
            var sql = @" SELECT Categories.Name AS CategoryName,  AVG(Ratings.RatingValue) AS AverageRating  FROM Products JOIN Categories ON Products.CategoryId = Categories.Id   JOIN Ratings ON Products.Id = Ratings.ProductId GROUP BY  Categories.Name; ";

            using (var connection = _context.Connection())
            {
    
                var result = connection.Query<CategoryRating>(sql).ToList();

                return result;
            }
        }
    }
    
    


   
}