

using Infrastructure.DataContext;
using Infrastructure.Services.CategoryService;
using Infrastructure.Services.MarketService;
using Infrastructure.Services.ProductService;
using Infrastructure.Services.QueryService;
using Infrastructure.Services.TableService;
using Infrastructure.Services.UserService;

CategoryService categoryService = new CategoryService();
MarketService marketService = new MarketService();
ProductService productService = new ProductService();
QueryService queryService = new QueryService();
CreateTableService createTableService = new CreateTableService();
UserService userService = new UserService();


DapperContext context;

context = new DapperContext();

var sql = "SELECT Users.Username, Markets.MarketName FROM Users LEFT JOIN Markets ON Users.Id = Markets.UserId;";
var  