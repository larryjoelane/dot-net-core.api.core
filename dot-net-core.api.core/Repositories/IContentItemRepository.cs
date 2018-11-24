using ContentService.Models;
using System.Collections.Generic;

namespace ContentService.Repository
{
    public interface IContentItemRepository
    {
        List<ContentItem> GetAllConentItemsAsync();
    }
}