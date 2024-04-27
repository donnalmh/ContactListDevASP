namespace ContactListDev.Models
{
    public class PaginationParams
    {
        private int itemsPerPage;
        private int _maxItemsPerPage = 100;

        public int Page { get; set; } = 1;

        public int ItemsPerPage
        {
            get => itemsPerPage; 
            set => itemsPerPage =  itemsPerPage > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
    }
}
