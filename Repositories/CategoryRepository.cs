namespace NorthwindLibrary
{
    public class CategoryRepository : ICategoryRepository, BaseRepository<Category>
    {
        public CategoryRepository(NorthwindDBContext _context):base(_context)
        {

        }

        public async Task<Category> GetByCategoryID(int categoryID)
        {
        }
    }
}