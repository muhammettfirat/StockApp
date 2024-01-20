namespace StockApp.Front.Modals
{
    public class GetListUserModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? AppRoleId { get; set; }
    }
}
